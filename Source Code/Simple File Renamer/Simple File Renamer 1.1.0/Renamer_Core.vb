Imports System.IO
Public Class Renamer_Core



    Inherits System.ComponentModel.Component

    ' Declares the variables you will use to hold your thread objects.

    Public FGThread As System.Threading.Thread


    Public Search_String As String = ""
    Public Replace_String As String = ""
    Public Include_Extension As Boolean = False
    Public Recursive_Replace As Boolean = False
    Public Working_Directory As String = ""
    Public Working_File As String = ""
    Public Result As String = ""
    Public Result_Total_Files_Processed As Integer = 0
    Public Result_Total_Files_Renamed As Integer = 0
    Public Result_Total_Rename_Fails As Integer = 0


    Private Count_Total As Integer = 0
    Private Count_Renamed As Integer = 0
    Private Count_Failed_Source As Integer = 0
    Private Count_Failed_Destination As Integer = 0
    Private Count_Failed_Invalid_Character As Integer = 0

    Public Event FGComplete(ByVal Result As String)
    Public Event FGProgress(ByVal value As Integer)
    Public Event FGSetProgress(ByVal value As Integer)


#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private Sub error_handler(ByVal message As String)
        Try
            MsgBox("Simple File Renamer 1.1 has trapped the following error: " & vbCrLf & message, MsgBoxStyle.Exclamation, "Simple File Renamer 1.1")
        Catch ex As Exception
            MsgBox("Simple File Renamer 1.1 has trapped the following error: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Simple File Renamer 1.1")
        End Try
    End Sub

    Public Sub ChooseThreads(ByVal threadNumber As Integer)
        Try
            ' Determines which thread to start based on the value it receives.
            Select Case threadNumber
                Case 1
                    ' Sets the thread using the AddressOf the subroutine where
                    ' the thread will start.
                    FGThread = New System.Threading.Thread(AddressOf FGExecute_String_Replace)
                    ' Starts the thread.
                    FGThread.Start()
                Case 2
                    ' Sets the thread using the AddressOf the subroutine where
                    ' the thread will start.
                    FGThread = New System.Threading.Thread(AddressOf FGExecute_File_Process)
                    ' Starts the thread.
                    FGThread.Start()
            End Select
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Public Sub FGExecute_String_Replace_Head(ByVal filewriter As StreamWriter)
        Try
            filewriter.WriteLine("<html>" & vbCrLf & "<body bgproperties=""fixed"" background=""" & Application.StartupPath() & "/Background_Image_Log_File.jpg" & """>" & vbCrLf & "<h1>Simple File Renamer 1.1 Log File</h1>")
            filewriter.WriteLine("<h3>Process Started: " & Now & "</h3>")
            filewriter.WriteLine("<p>Input Folder: " & Working_Directory & "</p>")
            filewriter.WriteLine("<ul>")
        Catch ex As Exception
            Result = "File generationg failed. Error encountered."
            RaiseEvent FGComplete(Result)
        End Try
    End Sub

    Public Sub FGExecute_String_Replace_Middle(ByVal filewriter As StreamWriter, ByVal working_directory As String, ByVal undowriter As StreamWriter)
        Try
            Dim find As String
            Dim replace As String
            find = Search_String
            replace = Replace_String

            Dim destread As String
            Dim filetomanipulate As File
            Dim foldercontents As DirectoryInfo
            foldercontents = New DirectoryInfo(working_directory)
            Dim filetocheck As FileInfo
            Dim lineread As String


            Dim filecountindir, looper As Integer
            filecountindir = 0
            looper = 0
            For Each filetocheck In foldercontents.GetFiles
                filecountindir = filecountindir + 1
            Next
            RaiseEvent FGSetProgress(filecountindir)
            For Each filetocheck In foldercontents.GetFiles
                looper = looper + 1
                lineread = filetocheck.FullName
                Dim lineread_name As String = filetocheck.Name
                Dim lineread_path = filetocheck.DirectoryName
                'Do While Not lineread Is Nothing
                Dim extension As String
                extension = ""
                If Include_Extension = False Then
                    If lineread_name.LastIndexOf(".") <> -1 Then

                        extension = lineread_name.Substring(lineread_name.LastIndexOf("."), lineread_name.Length - lineread_name.LastIndexOf("."))
                        lineread_name = lineread_name.Remove(lineread_name.LastIndexOf("."), lineread_name.Length - lineread_name.LastIndexOf("."))
                    End If
                End If
                destread = lineread_path & "\" & lineread_name.Replace(find, replace)
                If Include_Extension = False Then

                    destread = destread & extension
                End If
                If IsNothing(destread) = False Then


                    Count_Total = Count_Total + 1

                    If (Not destread = lineread) And (destread.Length > 0) And (Not destread = "") Then

                        Dim target As String = "/*?""<>|"
                        Dim anyOf As Char() = target.ToCharArray()
                        filewriter.WriteLine("<li>Source: " & lineread & "<br>")
                        filewriter.WriteLine("Destination: " & destread & "<br>")

                        If destread.IndexOfAny(anyOf) < 0 Or lineread.IndexOfAny(anyOf) < 0 Then
                            If filetomanipulate.Exists(lineread) = True Then

                                If filetomanipulate.Exists(destread) = False Then
                                    filetomanipulate.Move(lineread, destread)
                                    undowriter.WriteLine(destread)
                                    undowriter.WriteLine(lineread)
                                    Count_Renamed = Count_Renamed + 1
                                    filewriter.WriteLine("Action: Successfully Renamed<br>")
                                Else
                                    Count_Failed_Destination = Count_Failed_Destination + 1
                                    filewriter.WriteLine("Action: Rename Failed - Destination file already exists<br>")
                                End If

                            Else
                                Count_Failed_Source = Count_Failed_Source + 1
                                filewriter.WriteLine("Action: Rename Failed - Unable to locate source file<br>")
                            End If
                        Else
                            Count_Failed_Invalid_Character = Count_Failed_Invalid_Character + 1
                            filewriter.WriteLine("Action: Rename Failed - Invalid character present in file path<br>")
                        End If
                        filewriter.WriteLine("</li>")
                    End If


                End If
                ' Loop

                RaiseEvent FGProgress(looper)
            Next
            filetocheck = Nothing

            If Recursive_Replace = True Then
                Dim foldertocheck As DirectoryInfo
                For Each foldertocheck In foldercontents.GetDirectories
                    FGExecute_String_Replace_Middle(filewriter, foldertocheck.FullName, undowriter)
                Next
                foldertocheck = Nothing
            End If

            foldercontents = Nothing


        Catch ex As Exception
            Count_Failed_Invalid_Character = Count_Failed_Invalid_Character + 1
            filewriter.WriteLine("Action: Rename Failed - Invalid character present in file path<br>")
            Result = "File generationg failed. Error encountered."
            RaiseEvent FGComplete(Result)
        End Try
    End Sub

    Public Sub FGExecute_String_Replace_Tail(ByVal filewriter As StreamWriter)
        Try
            filewriter.WriteLine("</ul>")
            filewriter.WriteLine("<p>")
            filewriter.WriteLine("Total Files Processed: " & Count_Total & " files" & "<br>")
            filewriter.WriteLine("Total Files Renamed: " & Count_Renamed & " files" & "<br>")
            Dim totalfails As Integer = 0
            totalfails = Count_Failed_Source + Count_Failed_Destination + Count_Failed_Invalid_Character
            filewriter.WriteLine("Total Files Ignored: " & Count_Total - Count_Renamed - totalfails & " files" & "<br>")
            filewriter.WriteLine("Total Rename Fails: " & totalfails & " files" & "<br>")
            filewriter.WriteLine("<font color=""#C0C0C0"">")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Invalid Source Files: " & Count_Failed_Source & " files" & "<br>")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Destination Already Exists: " & Count_Failed_Destination & " files" & "<br>")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Invalid Character Sequence: " & Count_Failed_Invalid_Character & " files" & "<br>")
            filewriter.WriteLine("</font>")
            filewriter.WriteLine("</p>")

            filewriter.WriteLine("</body></html>")
        Catch ex As Exception
            Result = "File generationg failed. Error encountered."
            RaiseEvent FGComplete(Result)
        End Try
    End Sub

    Public Sub FGExecute_String_Replace()
        Try

            Count_Total = 0
            Count_Renamed = 0
            Count_Failed_Source = 0
            Count_Failed_Destination = 0
            Count_Failed_Invalid_Character = 0


            Dim filewriter As New StreamWriter(Application.StartupPath() & "\logfile.htm", False, System.Text.Encoding.ASCII)
            Dim undowriter As New StreamWriter(Application.StartupPath & "\undo.txt", False, System.Text.Encoding.ASCII)


            FGExecute_String_Replace_Head(filewriter)
            FGExecute_String_Replace_Middle(filewriter, Working_Directory, undowriter)
            FGExecute_String_Replace_Tail(filewriter)


            undowriter.Close()
            filewriter.Close()

            Result_Total_Files_Processed = Count_Total
            Result_Total_Files_Renamed = Count_Renamed
            Result_Total_Rename_Fails = (Count_Total - Count_Renamed)
            Result = "Rename Process Complete. " & Count_Renamed & " files out of " & Count_Total & " were renamed."
            RaiseEvent FGComplete(Result)
        Catch ex As Exception
            Result = "File generationg failed. Error encountered."
            RaiseEvent FGComplete(Result)
        End Try
    End Sub

    Public Sub FGExecute_File_Process()
        Try
            Count_Total = 0
            Count_Renamed = 0
            Count_Failed_Source = 0
            Count_Failed_Destination = 0
            Count_Failed_Invalid_Character = 0

            Dim filereader As New StreamReader(Working_File, True)
            Dim lineread As String = filereader.ReadLine
            Dim destread As String
            Dim filetomanipulate As File


            Dim f As FileInfo
            f = New FileInfo(Application.ExecutablePath())

            Dim filewriter As New StreamWriter(f.DirectoryName() & "\logfile.htm", False, System.Text.Encoding.ASCII)
            Dim undowriter As New StreamWriter(Application.StartupPath & "\undo.txt", False, System.Text.Encoding.ASCII)


            filewriter.WriteLine("<html>" & vbCrLf & "<body bgproperties=""fixed"" background=""" & f.DirectoryName() & "/Background_Image_Log_File.jpg" & """>" & vbCrLf & "<h1>Simple File Renamer 1.1 Log File</h1>")
            filewriter.WriteLine("<h3>Process Started: " & Now & "</h3>")
            filewriter.WriteLine("<p>Input File: " & Working_File & "</p>")
            filewriter.WriteLine("<ul>")

            Dim looper As Integer = 0
            RaiseEvent FGSetProgress(100)

            Do While Not lineread Is Nothing
                lineread = lineread.Trim()
                destread = filereader.ReadLine
                If (Not lineread Is Nothing) And (Not destread Is Nothing) Then


                    Count_Total = Count_Total + 1
                    looper = looper + 1
                    Dim target As String = "/*?""<>|"
                    Dim anyOf As Char() = target.ToCharArray()
                    filewriter.WriteLine("<li>Source: " & lineread & "<br>")
                    filewriter.WriteLine("Destination: " & destread & "<br>")

                    If destread.IndexOfAny(anyOf) < 0 Or lineread.IndexOfAny(anyOf) < 0 Then
                        If filetomanipulate.Exists(lineread) = True Then

                            If filetomanipulate.Exists(destread) = False Then
                                filetomanipulate.Move(lineread, destread)
                                undowriter.WriteLine(destread)
                                undowriter.WriteLine(lineread)
                                Count_Renamed = Count_Renamed + 1
                                filewriter.WriteLine("Action: Successfully Renamed<br>")
                            Else
                                Count_Failed_Destination = Count_Failed_Destination + 1
                                filewriter.WriteLine("Action: Rename Failed - Destination file already exists<br>")
                            End If

                        Else
                            Count_Failed_Source = Count_Failed_Source + 1
                            filewriter.WriteLine("Action: Rename Failed - Unable to locate source file<br>")
                        End If
                    Else
                        Count_Failed_Invalid_Character = Count_Failed_Invalid_Character + 1
                        filewriter.WriteLine("Action: Rename Failed - Invalid character present in file path<br>")
                    End If
                    filewriter.WriteLine("</li>")
                End If
                If (destread Is Nothing) Then
                    lineread = destread
                Else
                    lineread = filereader.ReadLine
                End If
                If looper >= 100 Then looper = 1
                RaiseEvent FGProgress(looper)
            Loop
            filewriter.WriteLine("</ul>")

            filewriter.WriteLine("<p>")
            filewriter.WriteLine("Total Files Processed: " & Count_Total & " files" & "<br>")
            filewriter.WriteLine("Total Files Renamed: " & Count_Renamed & " files" & "<br>")
            filewriter.WriteLine("Total Rename Fails: " & (Count_Total - Count_Renamed) & " files" & "<br>")
            filewriter.WriteLine("<font color=""#C0C0C0"">")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Invalid Source Files: " & Count_Failed_Source & " files" & "<br>")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Destination Already Exists: " & Count_Failed_Destination & " files" & "<br>")
            filewriter.WriteLine("&nbsp;&nbsp;&nbsp;Invalid Character Sequence: " & Count_Failed_Invalid_Character & " files" & "<br>")
            filewriter.WriteLine("</font>")
            filewriter.WriteLine("</p>")

            filewriter.WriteLine("</body></html>")
            filewriter.Close()
            filereader.Close()
            undowriter.Close()

            Result_Total_Files_Processed = Count_Total
            Result_Total_Files_Renamed = Count_Renamed
            Result_Total_Rename_Fails = (Count_Total - Count_Renamed)

            Result = "Rename Process Complete. " & Count_Renamed & " files out of " & Count_Total & " were renamed."
            RaiseEvent FGProgress(100)
            RaiseEvent FGComplete(Result)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Result = "File generation failed. Error encountered."
            RaiseEvent FGComplete(Result)
        End Try
    End Sub







End Class
