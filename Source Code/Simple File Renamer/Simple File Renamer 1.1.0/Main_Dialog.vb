Imports System.IO
Public Class Main_Dialog
    Inherits System.Windows.Forms.Form

    Dim WithEvents Renamer_Core1 As Renamer_Core
    Public Delegate Sub FileGeneratorhHandler(ByVal Result As String)
    Public Delegate Sub FGProgresshHandler(ByVal Result As String)
    Public Delegate Sub FGSetProgresshHandler(ByVal Result As String)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Renamer_Core1 = New Renamer_Core
        AddHandler Renamer_Core1.FGComplete, AddressOf FileGeneratorHandler
        AddHandler Renamer_Core1.FGProgress, AddressOf FGProgressHandler
        AddHandler Renamer_Core1.FGSetProgress, AddressOf FGSetProgressHandler
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Help_Panel As System.Windows.Forms.Panel
    Friend WithEvents About_Panel As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Replace As System.Windows.Forms.TextBox
    Friend WithEvents Include_File_Extension As System.Windows.Forms.CheckBox
    Friend WithEvents Find As System.Windows.Forms.TextBox
    Friend WithEvents Recursive_Renaming As System.Windows.Forms.CheckBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Process_Input_File As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents viewlogfile As System.Windows.Forms.Label
    Friend WithEvents Undo_Renames As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main_Dialog))
        Me.Button1 = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Help_Panel = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.About_Panel = New System.Windows.Forms.Panel
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Replace = New System.Windows.Forms.TextBox
        Me.Include_File_Extension = New System.Windows.Forms.CheckBox
        Me.Find = New System.Windows.Forms.TextBox
        Me.Recursive_Renaming = New System.Windows.Forms.CheckBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Process_Input_File = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.viewlogfile = New System.Windows.Forms.Label
        Me.Undo_Renames = New System.Windows.Forms.Label
        Me.Help_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.About_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightPink
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(248, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 18)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Rename Files"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(24, 240)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(216, 18)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(425, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Exit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 24)
        Me.Label2.TabIndex = 27
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label5.Location = New System.Drawing.Point(24, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(352, 24)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Simple File Renamer 1.1 "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(424, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Help"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(424, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "About"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Help_Panel
        '
        Me.Help_Panel.BackColor = System.Drawing.Color.Transparent
        Me.Help_Panel.Controls.Add(Me.Label12)
        Me.Help_Panel.Controls.Add(Me.Panel1)
        Me.Help_Panel.Controls.Add(Me.Panel2)
        Me.Help_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Help_Panel.Name = "Help_Panel"
        Me.Help_Panel.Size = New System.Drawing.Size(1, 1)
        Me.Help_Panel.TabIndex = 33
        Me.Help_Panel.Visible = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(24, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(352, 24)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Simple File Renamer 1.1 "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Location = New System.Drawing.Point(16, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 256)
        Me.Panel1.TabIndex = 33
        Me.Panel1.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.DarkGray
        Me.Label31.Location = New System.Drawing.Point(4, 40)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(408, 28)
        Me.Label31.TabIndex = 47
        Me.Label31.Text = "The string length variable allows you to adjust the string length of the counter " & _
        "by adding zeros to the front of the number."
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(352, 236)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 46
        Me.Label26.Text = "<< BACK"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.DarkGray
        Me.Label25.Location = New System.Drawing.Point(4, 202)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(408, 48)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "Once you have successfully set up your downloads, click on the ‘Generate File’ bu" & _
        "tton to begin the actual process. A save file dialog will appear, asking you to " & _
        "select the destination for the generated .dal list."
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkGray
        Me.Label24.Location = New System.Drawing.Point(270, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 20)
        Me.Label24.TabIndex = 44
        Me.Label24.Text = "http://www.images.com/3.jpg;"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkGray
        Me.Label23.Location = New System.Drawing.Point(138, 132)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(152, 20)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "http://www.images.com/2.jpg;"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkGray
        Me.Label17.Location = New System.Drawing.Point(344, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "(Page 2/2)"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.DarkGray
        Me.Label16.Location = New System.Drawing.Point(4, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(408, 40)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "To add multiple URLS for download, simply delimit them using the ‘;’ character. F" & _
        "or example, http://www.images.com/@.jpg; http://www.images.com/file@.bmp will re" & _
        "sult in 10 files being made available for download."
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkGray
        Me.Label15.Location = New System.Drawing.Point(4, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(156, 20)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "http://www.images.com/1.jpg;"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.DarkGray
        Me.Label13.Location = New System.Drawing.Point(4, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(412, 56)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "The second step is the input of the actual download URL. The delimiter character " & _
        "used to input the counter variable for a series download is ‘@’. In other words," & _
        " inputting an URL such as http://www.images.com/@.jpg with the series listing ab" & _
        "ove will result in the following file download list:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(4, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 24)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Help "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Location = New System.Drawing.Point(16, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 256)
        Me.Panel2.TabIndex = 43
        Me.Panel2.Visible = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(352, 236)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 16)
        Me.Label27.TabIndex = 47
        Me.Label27.Text = "NEXT >>"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkGray
        Me.Label18.Location = New System.Drawing.Point(344, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "(Page 1/2)"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.DarkGray
        Me.Label19.Location = New System.Drawing.Point(4, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(408, 56)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "To use the program is simple enough. There is a start, end and step counter contr" & _
        "ol which allows you to control the series numbering. Thus, a choice of a start v" & _
        "alue of 1 and an end value of 3 with a step value of 1 will result in a series l" & _
        "ooking like: 1,2,3."
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.DarkGray
        Me.Label20.Location = New System.Drawing.Point(4, 108)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(396, 72)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "For instance, an image gallery may host 15 files (in series) at the following add" & _
        "ress: http://www.images.com/1.jpg, http://www.images.com/2.jpg, etc... Now by se" & _
        "tting the counter variables correctly and inputting the URL in the correct forma" & _
        "t, we can generate a single .dal file for later use with DAP. This generated .da" & _
        "l file will then contain download information for all 15 images."
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.Color.DarkGray
        Me.Label21.Location = New System.Drawing.Point(4, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(408, 56)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "The download manager program, Download Accelerator Plus (DAP), can load files for" & _
        " download from its custom formal .dal file. Simple File Renamer 1.1 is a program" & _
        " for generating .dal lists, specifically suited towards the creation of file ser" & _
        "ies downloads."
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(4, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 24)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Help "
        '
        'About_Panel
        '
        Me.About_Panel.BackColor = System.Drawing.Color.Transparent
        Me.About_Panel.Controls.Add(Me.Label32)
        Me.About_Panel.Controls.Add(Me.Label33)
        Me.About_Panel.Controls.Add(Me.Label34)
        Me.About_Panel.Controls.Add(Me.Label35)
        Me.About_Panel.Controls.Add(Me.Label36)
        Me.About_Panel.Controls.Add(Me.Label37)
        Me.About_Panel.Controls.Add(Me.Label38)
        Me.About_Panel.Controls.Add(Me.Label39)
        Me.About_Panel.Controls.Add(Me.Label28)
        Me.About_Panel.Controls.Add(Me.Label29)
        Me.About_Panel.Location = New System.Drawing.Point(0, 0)
        Me.About_Panel.Name = "About_Panel"
        Me.About_Panel.Size = New System.Drawing.Size(1, 1)
        Me.About_Panel.TabIndex = 33
        Me.About_Panel.Visible = False
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(96, 88)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(40, 16)
        Me.Label32.TabIndex = 49
        Me.Label32.Text = "1.1.0"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(96, 120)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 16)
        Me.Label33.TabIndex = 48
        Me.Label33.Text = "Craig Lotter"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(24, 72)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 16)
        Me.Label34.TabIndex = 47
        Me.Label34.Text = "Version:"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(24, 120)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(64, 16)
        Me.Label35.TabIndex = 46
        Me.Label35.Text = "Developer:"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(24, 104)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(56, 16)
        Me.Label36.TabIndex = 45
        Me.Label36.Text = "Created:"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(96, 104)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(104, 16)
        Me.Label37.TabIndex = 44
        Me.Label37.Text = "2004/11/16"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(24, 88)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(56, 16)
        Me.Label38.TabIndex = 43
        Me.Label38.Text = "Build:"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(96, 72)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(176, 16)
        Me.Label39.TabIndex = 42
        Me.Label39.Text = "Simple File Renamer 1.1"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label28.Location = New System.Drawing.Point(24, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(352, 24)
        Me.Label28.TabIndex = 40
        Me.Label28.Text = "Simple File Renamer 1.1 "
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label29.Location = New System.Drawing.Point(24, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 24)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "About"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label3.Location = New System.Drawing.Point(24, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Replace With:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label4.Location = New System.Drawing.Point(24, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Search for:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label6.Location = New System.Drawing.Point(24, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(328, 48)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Simple File Renamer 1.1 is a program that allows you to rename a number of files " & _
        "based on a simple case-sensitive search and replace operation or a fixed-format " & _
        "input text file."
        '
        'Replace
        '
        Me.Replace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Replace.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Replace.Location = New System.Drawing.Point(24, 164)
        Me.Replace.Multiline = True
        Me.Replace.Name = "Replace"
        Me.Replace.Size = New System.Drawing.Size(296, 32)
        Me.Replace.TabIndex = 35
        Me.Replace.Text = ""
        '
        'Include_File_Extension
        '
        Me.Include_File_Extension.BackColor = System.Drawing.Color.Transparent
        Me.Include_File_Extension.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Include_File_Extension.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Include_File_Extension.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Include_File_Extension.ForeColor = System.Drawing.Color.Black
        Me.Include_File_Extension.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Include_File_Extension.Location = New System.Drawing.Point(32, 200)
        Me.Include_File_Extension.Name = "Include_File_Extension"
        Me.Include_File_Extension.Size = New System.Drawing.Size(248, 24)
        Me.Include_File_Extension.TabIndex = 36
        Me.Include_File_Extension.Text = "Include file extension in search"
        Me.Include_File_Extension.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'Find
        '
        Me.Find.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Find.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Find.Location = New System.Drawing.Point(24, 110)
        Me.Find.Multiline = True
        Me.Find.Name = "Find"
        Me.Find.Size = New System.Drawing.Size(296, 32)
        Me.Find.TabIndex = 34
        Me.Find.Text = ""
        '
        'Recursive_Renaming
        '
        Me.Recursive_Renaming.BackColor = System.Drawing.Color.Transparent
        Me.Recursive_Renaming.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Recursive_Renaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Recursive_Renaming.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recursive_Renaming.ForeColor = System.Drawing.Color.Black
        Me.Recursive_Renaming.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Recursive_Renaming.Location = New System.Drawing.Point(32, 216)
        Me.Recursive_Renaming.Name = "Recursive_Renaming"
        Me.Recursive_Renaming.Size = New System.Drawing.Size(180, 24)
        Me.Recursive_Renaming.TabIndex = 40
        Me.Recursive_Renaming.Text = "Recursive rename process"
        Me.Recursive_Renaming.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select the folder to be processed."
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Process_Input_File
        '
        Me.Process_Input_File.BackColor = System.Drawing.Color.Transparent
        Me.Process_Input_File.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process_Input_File.ForeColor = System.Drawing.Color.White
        Me.Process_Input_File.Location = New System.Drawing.Point(352, 232)
        Me.Process_Input_File.Name = "Process_Input_File"
        Me.Process_Input_File.Size = New System.Drawing.Size(112, 16)
        Me.Process_Input_File.TabIndex = 41
        Me.Process_Input_File.Text = "Process File"
        Me.Process_Input_File.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "txt"
        Me.OpenFileDialog1.Filter = "Text files|*.txt|All files|*.*"
        Me.OpenFileDialog1.Title = "Select an input file to parse"
        '
        'viewlogfile
        '
        Me.viewlogfile.BackColor = System.Drawing.Color.Transparent
        Me.viewlogfile.Enabled = False
        Me.viewlogfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewlogfile.ForeColor = System.Drawing.Color.Black
        Me.viewlogfile.Location = New System.Drawing.Point(24, 240)
        Me.viewlogfile.Name = "viewlogfile"
        Me.viewlogfile.Size = New System.Drawing.Size(96, 16)
        Me.viewlogfile.TabIndex = 42
        Me.viewlogfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Undo_Renames
        '
        Me.Undo_Renames.BackColor = System.Drawing.Color.Transparent
        Me.Undo_Renames.Enabled = False
        Me.Undo_Renames.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Undo_Renames.ForeColor = System.Drawing.Color.Black
        Me.Undo_Renames.Location = New System.Drawing.Point(128, 240)
        Me.Undo_Renames.Name = "Undo_Renames"
        Me.Undo_Renames.Size = New System.Drawing.Size(112, 16)
        Me.Undo_Renames.TabIndex = 43
        Me.Undo_Renames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Main_Dialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(481, 302)
        Me.Controls.Add(Me.Process_Input_File)
        Me.Controls.Add(Me.About_Panel)
        Me.Controls.Add(Me.Help_Panel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Recursive_Renaming)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Replace)
        Me.Controls.Add(Me.Include_File_Extension)
        Me.Controls.Add(Me.Find)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.viewlogfile)
        Me.Controls.Add(Me.Undo_Renames)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(481, 302)
        Me.MinimumSize = New System.Drawing.Size(481, 302)
        Me.Name = "Main_Dialog"
        Me.Text = "Simple File Renamer 1.1"
        Me.Help_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.About_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const WM_NCHITTEST As Integer = &H84
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If (m.Result.ToInt32 = HTCLIENT) Then
                    m.Result = IntPtr.op_Explicit(HTCAPTION)
                End If
                Exit Sub
        End Select

        MyBase.WndProc(m)
    End Sub

    Private Sub error_handler(ByVal message As String)
        Try
            If message.Length > 0 Then
                MsgBox("Sorry, but Simple File Renamer 1.1 has trapped the following error: " & vbCrLf & message, MsgBoxStyle.Exclamation, "Simple File Renamer 1.1")
            End If
        Catch ex As Exception
            MsgBox("Sorry, but Simple File Renamer 1.1 has trapped the following error: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Simple File Renamer 1.1")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim result As DialogResult

            result = FolderBrowserDialog1.ShowDialog


            If result = DialogResult.OK And Find.Text.Length > 0 Then
                viewlogfile.Enabled = False
                viewlogfile.Text = ""
                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                Label2.Text = "Renaming files..."
                Button1.Enabled = False
                Process_Input_File.Enabled = False

                Renamer_Core1.Search_String = Find.Text

                Renamer_Core1.Replace_String = Replace.Text
                Renamer_Core1.Include_Extension = Include_File_Extension.Checked
                Renamer_Core1.Recursive_Replace = Recursive_Renaming.Checked
                Renamer_Core1.Working_Directory = FolderBrowserDialog1.SelectedPath

                FolderBrowserDialog1.Dispose()
                Renamer_Core1.ChooseThreads(1)

            End If
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub





    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Try
            Application.Exit()
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Public Sub FileGeneratorHandler(ByVal Result As String)
        Try
            ' Displays the returned value in the appropriate label.
            ProgressBar1.Visible = False
            ProgressBar1.Value = 0
            Label2.Text = Result
            Process_Input_File.Enabled = True
            
            If Find.Text.Length > 0 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
            viewlogfile.Enabled = True
            viewlogfile.Text = "VIEW LOG FILE"

            Undo_Renames.Enabled = True
            Undo_Renames.Text = "UNDO LAST ACTION"
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Public Sub FGProgressHandler(ByVal value As Integer)
        Try
            ' Displays the returned value in the appropriate label.
            ProgressBar1.Value = value

        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Public Sub FGSetProgressHandler(ByVal value As Integer)
        Try
            ' Displays the returned value in the appropriate label.
            ProgressBar1.Maximum = value
            ProgressBar1.Value = 0
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub









    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click
        Try
            Panel2.Visible = True
            Panel1.Visible = False
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label27.Click
        Try
            Panel1.Visible = True
            Panel2.Visible = False
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Try
            Dim helpscreen As New Help
            'Dim result As DialogResult
            'result = helpscreen.ShowDialog()
            helpscreen.Show()
            'helpscreen.Dispose()
        Catch et As Exception
            error_handler(et.Message)
        End Try

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Try

            Dim si As Size

            If About_Panel.Visible = True Then

                si = New Size(1, 1)
                About_Panel.Size = si
                About_Panel.Visible = False
            Else
                If Help_Panel.Visible = True Then
                    Panel1.Visible = False
                    Panel2.Visible = True
                    si = New Size(1, 1)
                    Help_Panel.Size = si
                    Help_Panel.Visible = False
                End If
                si = New Size(424, 302)
                About_Panel.Size = si
                About_Panel.Visible = True

            End If
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Private Sub Find_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Find.TextChanged
        Try
            If Find.Text.Length > 0 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        Catch ex As Exception
            error_handler(ex.Message)
        End Try

    End Sub

    Private Sub Process_Input_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Process_Input_File.Click
        Try
            Dim result As DialogResult

            result = OpenFileDialog1.ShowDialog


            If result = DialogResult.OK Then
                viewlogfile.Enabled = False
                viewlogfile.Text = ""
                ProgressBar1.Visible = True
                Label2.Text = "Renaming files..."
                Button1.Enabled = False
                Process_Input_File.Enabled = False
                Renamer_Core1.Working_File = OpenFileDialog1.FileName
                OpenFileDialog1.Dispose()
                Renamer_Core1.ChooseThreads(2)
            End If
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewlogfile.Click
        Try
            Dim f As FileInfo
            f = New FileInfo(Application.ExecutablePath())
            System.Diagnostics.Process.Start(f.DirectoryName() & "\logfile.htm")
        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub


    Private Sub Undo_Renames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Undo_Renames.Click
        Try
            viewlogfile.Enabled = False
            viewlogfile.Text = ""
            Undo_Renames.Enabled = False
            Undo_Renames.Text = ""
                ProgressBar1.Visible = True
                Label2.Text = "Renaming files..."
                Button1.Enabled = False
            Process_Input_File.Enabled = False
            Dim filetomanipulate As File
            If filetomanipulate.Exists(Application.StartupPath & "\process_undo.txt") = True Then
                filetomanipulate.Delete(Application.StartupPath & "\process_undo.txt")
            End If
            filetomanipulate.Move(Application.StartupPath & "\undo.txt", Application.StartupPath & "\process_undo.txt")
            Renamer_Core1.Working_File = Application.StartupPath & "\process_undo.txt"
            Renamer_Core1.ChooseThreads(2)

        Catch ex As Exception
            error_handler(ex.Message)
        End Try
    End Sub
End Class
