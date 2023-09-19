Imports System.Data.SqlClient
Public Class login
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    'Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steph\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As SqlCommand = New SqlCommand("select *from users where Name='" + username.Text + "' and Password='" + password.Text + "'", con)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        If (dt.Rows.Count > 0) Then
            MessageBox.Show("Login successful", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dashboardd.Show()
        Else
            MessageBox.Show("Please enter valid details", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class