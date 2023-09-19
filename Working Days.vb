Imports System.Data.SqlClient
Public Class test22
    'Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steph\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30")
    'Dim con As New SqlConnection("Server=(LocalDB)\MSSQLLocalDB;Database=LMS;Trusted_Connection=True")
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")

    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")


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
    Private Sub WorkingDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fillcombo()
        populate()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Label3.Text = 2
    End Sub

    Private Sub Label3_TextChanged(sender As Object, e As EventArgs) Handles Label3.TextChanged
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            Label9.Text = Val(Label3.Text) + Val(Button3.Text)

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DateTimePicker1.Text = "" Or Label3.Text = "" Or Label9.Text = "" Or Button1.Text = "" Or Button2.Text = "" Or Button3.Text = "" Then
            MsgBox("Incomplete Data")
        Else
            con.Open()
            Dim cmd As New SqlCommand("UPDATE [dbo].[details]" & " SET [Dates_worked]= '" + DateTimePicker1.Text + "',[New_off_days]='" + Label3.Text + "',[Total_of_days]='" + Label9.Text + "',[Number_of_offs]='" + Label9.Text + "' WHERE [Employee_name]='" + ComboBox1.Text + "' ", con)
            cmd.ExecuteNonQuery()
            MsgBox("details Succesfully Updated")
            con.Close()
            populate()


        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Dim hom = New Dashboardd
        hom.Show()
    End Sub

    Private Sub DateTimePicker1_MouseHover(sender As Object, e As EventArgs) Handles DateTimePicker1.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            Label9.Text = Val(Label3.Text) + Val(Button3.Text)

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button1.Text = ""
        Button2.Text = ""
        Button3.Text = ""
        DateTimePicker1.Text = ""
        Label3.Text = ""
        Label3.Text = ""
        Label9.Text = ""
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            'Label9.Text = Val(Label3.Text) + Val(Button3.Text)

        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            'Label9.Text = Val(Label3.Text) + Val(Button3.Text)

        End If
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover

        If Button3.Text = "" Then
            MsgBox("Please querry first")
        Else
            'Label9.Text = Val(Label3.Text) + Val(Button3.Text)

        End If
    End Sub

    Private Sub Button3_TextChanged(sender As Object, e As EventArgs) Handles Button3.TextChanged
        Label3.Text = 2
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class