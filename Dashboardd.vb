Public Class Dashboardd
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnIndividualmembership_Click(sender As Object, e As EventArgs) Handles btnIndividualmembership.Click

        Me.Hide()
        Dim med = New test
        test.Show()

    End Sub

    Private Sub InstitutionMembership_Click(sender As Object, e As EventArgs) Handles InstitutionMembership.Click
        Me.Hide()
        Dim med = New test22
        test22.Show()
    End Sub

    Private Sub Firsttimebookloan_Click(sender As Object, e As EventArgs) Handles Firsttimebookloan.Click
        Me.Hide()
        Dim med = New RegisterEmployee
        med.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim med = New GeneralReport
        GeneralReport.Show()
    End Sub

    Private Sub Dashboardd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbldate.Text = Date.Now.ToString("MMMM/ddddd/yyyy")
        lbltime.Text = TimeOfDay.ToString("hh:mmm")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub leftside_Paint(sender As Object, e As PaintEventArgs) Handles leftside.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim med = New manage_users
        med.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class