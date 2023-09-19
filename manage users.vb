Imports System.Data.SqlClient
Public Class manage_users
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    'Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steph\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub populate()
        con.Open()
        Dim sql = "select * from users"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        agentGV.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub Fillcombo()
        con.Open()
        Dim cmd As New SqlCommand("select * from users", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        ComboBox1.DataSource = Tbl
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "Name"
        con.Close()
    End Sub
    Private Sub manage_users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        Fillcombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If pf_number.Text = "" Or employeename.Text = "" Or password.Text = "" Then
            MsgBox("Incomplete Data")
        Else
            con.Open()
            Dim query As String
            query = "insert into users (p_f_number,Name,password) VALUES('" & pf_number.Text & "','" & employeename.Text & "','" & password.Text & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Information succesfully Aded")
            con.Close()
            populate()


        End If



    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If employeename.Text = "" Or password.Text = "" Or pf_number.Text = "" Then
            MsgBox("Please Querry Data")
        Else
            con.Open()
            Dim cmd As New SqlCommand("update users set p_f_number= '" & pf_number.Text & "',Name='" & employeename.Text & "',password='" & password.Text & "' WHERE Name='" & ComboBox1.Text & "' ", con)
            cmd.ExecuteNonQuery()
            MsgBox("details Succesfully Updated")
            con.Close()
            populate()


        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If pf_number.Text = "" Or password.Text = "" Or employeename.Text = "" Then
            MsgBox("Please Querry Data")
        Else
            con.Open()
            Dim query As String
            query = "delete from users WHERE p_f_number= '" & pf_number.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Succesfully Deleted")
            con.Close()
            populate()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        'lbltotalrenuedbooks.Text = ""
        Dim conmmand As New SqlCommand("SELECT * FROM users WHERE Name =@Name", con)

        conmmand.Parameters.Add("Name", SqlDbType.VarChar).Value = ComboBox1.SelectedValue.ToString()

        Dim reader As SqlDataReader


        reader = conmmand.ExecuteReader()

        If reader.Read() Then
            pf_number.Text = reader(0)
            employeename.Text = reader(1)
            password.Text = reader(2)

        End If
        con.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        pf_number.Text = ""
        employeename.Text = ""
        password.Text = ""
    End Sub

    Private Sub agentGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles agentGV.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim hom = New Dashboardd
        hom.Show()
    End Sub
End Class