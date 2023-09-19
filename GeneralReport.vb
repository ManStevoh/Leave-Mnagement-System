Imports System.Data.SqlClient
Public Class GeneralReport
    Dim con As New SqlConnection("Server=(DESKTOP-F3FU9LM\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
    'Dim con As New SqlConnection("Server=(DESKTOP-34A9630\SQLEXPRESS;Database=LMS;Trusted_Connection=True")
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

    Private Sub GeneralReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        Fillcombo()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim hom = New Dashboardd
        hom.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        con.Open()
        'lbltotalrenuedbooks.Text = ""
        Dim conmmand As New SqlCommand("SELECT * FROM details WHERE Employee_name =@Employee_name", con)

        conmmand.Parameters.Add("Employee_name", SqlDbType.VarChar).Value = ComboBox1.SelectedValue.ToString()

        Dim reader As SqlDataReader


        reader = conmmand.ExecuteReader()

        If reader.Read() Then
            Button1.Text = reader(0)
            Button2.Text = reader(1)
            Button3.Text = reader(2)
            Button4.Text = reader(6)

        End If
        con.Close()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button1.Text = ""
        Button2.Text = ""
        Button3.Text = ""
        Button4.Text = ""

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class