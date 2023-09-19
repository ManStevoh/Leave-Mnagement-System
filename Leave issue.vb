Imports System.Data.SqlClient
Public Class test
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    'Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steph\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub populate()
        con.Open()
        Dim sql = "select * from details"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub Fillcombo()
        con.Open()
        Dim cmd As New SqlCommand("select * from details", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        ComboBox1.DataSource = Tbl
        ComboBox1.DisplayMember = "Employee_name"
        ComboBox1.ValueMember = "Employee_name"
        con.Close()
    End Sub
    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fillcombo()
        populate()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1.Text = ""
        Button2.Text = ""
        Button3.Text = ""
        Txtofftaken.Text = ""
        Label3.Text = ""
        DateTimePicker1.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Txtofftaken.TextChanged
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            Label3.Text = Val(Button3.Text) - Val(Txtofftaken.Text)

        End If

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Txtofftaken.Text = "" Or Label3.Text = "" Or DateTimePicker1.Text = "" Or Button1.Text = "" Or Button2.Text = "" Or Button3.Text = "" Then
            MsgBox("Incomplete Data")
        Else
            con.Open()
            Dim cmd As New SqlCommand("UPDATE [dbo].[details]" & " SET [Offs_Taken]= '" + Txtofftaken.Text + "',[New_available_offs]='" + Label3.Text + "',[Total_of_days]='" + Label3.Text + "',[Dates]='" + DateTimePicker1.Text + "',[Number_of_offs]='" + Label3.Text + "' WHERE [Employee_name]='" + ComboBox1.Text + "' ", con)
            cmd.ExecuteNonQuery()
            MsgBox("details Succesfully Updated")
            con.Close()
            populate()
        End If
    End Sub
    Private Sub Txtofftaken_MouseHover(sender As Object, e As EventArgs) Handles Txtofftaken.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            Label3.Text = Val(Button3.Text) - Val(Txtofftaken.Text)

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        con.Open()
        'lbltotalrenuedbooks.Text = ""
        Dim conmmand As New SqlCommand("SELECT * FROM details WHERE Employee_name=@Employee_name", con)

        conmmand.Parameters.Add("Employee_name", SqlDbType.VarChar).Value = ComboBox1.SelectedValue.ToString()

        Dim reader As SqlDataReader


        reader = conmmand.ExecuteReader()

        If reader.Read() Then
            Button1.Text = reader(0)
            Button2.Text = reader(1)
            Button3.Text = reader(2)

        End If
        con.Close()
    End Sub

    Private Sub DateTimePicker1_MouseHover(sender As Object, e As EventArgs) Handles DateTimePicker1.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else


        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else


        End If
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else


        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim hom = New Dashboardd
        hom.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class