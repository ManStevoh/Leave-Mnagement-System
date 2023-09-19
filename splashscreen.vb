Public Class splashscreen
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        myprogresbar.Increment(1)
        If myprogresbar.Value = 1000 Then
            Me.Hide()
            Dim log = New login
            log.Show()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub myprogresbar_Click(sender As Object, e As EventArgs) Handles myprogresbar.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub splashscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class