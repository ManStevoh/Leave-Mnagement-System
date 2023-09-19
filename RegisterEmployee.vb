Imports System.Data.SqlClient
Public Class RegisterEmployee
    'Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steph\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30")
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
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
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        Fillcombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If textname.Text = "" Or textpfno.Text = "" Or textnooffs.Text = "" Then
            MsgBox("Incomplete Data")
        Else
            con.Open()
            Dim query As String
            query = "insert into details (Employee_name,pf_number,Number_of_offs) VALUES('" & textname.Text & "','" & textpfno.Text & "','" & textnooffs.Text & "')"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Information succesfully Aded")
            con.Close()
            populate()


        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        If textname.Text = "" Or textpfno.Text = "" Or textnooffs.Text = "" Then
            MsgBox("Incomplete Data")
        Else
            con.Open()
            Dim cmd As New SqlCommand("update details set Employee_name= '" & textname.Text & "',pf_number='" & textpfno.Text & "',Number_of_offs='" & textnooffs.Text & "' WHERE pf_number='" & textpfno.Text & "' ", con)
            cmd.ExecuteNonQuery()
            MsgBox("details Succesfully Updated")
            con.Close()
            populate()
            textname.Text = ""
            textnooffs.Text = ""
            textpfno.Text = ""

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim hom = New Dashboardd
        hom.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If textpfno.Text = "" Or textname.Text = "" Or textnooffs.Text = "" Then
            MsgBox("Please Querry Data")
        Else
            con.Open()
            Dim cmd As New SqlCommand("update details set pf_number= '" & textpfno.Text & "',Employee_name='" & textname.Text & "',Number_of_offs='" & textnooffs.Text & "' WHERE Employee_name='" & ComboBox1.Text & "' ", con)
            cmd.ExecuteNonQuery()
            MsgBox("details Succesfully Updated")
            con.Close()
            populate()

            textname.Text = ""
            textnooffs.Text = ""
            textpfno.Text = ""
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If textpfno.Text = "" Or textname.Text = "" Or textnooffs.Text = "" Then
            MsgBox("Please Querry Data")
        Else
            con.Open()
            Dim query As String
            query = "delete from details WHERE Employee_name= '" & ComboBox1.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Succesfully Deleted")
            con.Close()
            populate()
            textname.Text = ""
            textnooffs.Text = ""
            textpfno.Text = ""

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        textname.Text = ""
        textnooffs.Text = ""
        textpfno.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then
            MsgBox("No Data is selected")
        Else
            con.Open()
            'lbltotalrenuedbooks.Text = ""
            Dim conmmand As New SqlCommand("SELECT * FROM details WHERE Employee_name =@Employee_name", con)

            conmmand.Parameters.Add("Employee_name", SqlDbType.VarChar).Value = ComboBox1.SelectedValue.ToString()

            Dim reader As SqlDataReader


            reader = conmmand.ExecuteReader()

            If reader.Read() Then
                textpfno.Text = reader(1)
                textname.Text = reader(0)
                textnooffs.Text = reader(2)

            End If
            con.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class