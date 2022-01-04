Public Class Form1
    Public Structure NodeIndex
        Dim X As Integer
        Dim Y As Integer
        Dim Done As Boolean
        Dim Index As Integer
    End Structure
    Public Structure DysList
        Dim NodeIndexINT As Integer
        Dim NodeIndex2DArray As NodeIndex
        Dim Distance As Integer
        Dim previous As Integer
    End Structure

    Public CurrentSession As Session
    Public Sub SetSquareColour(ByVal c As Color, ByVal square As NodeIndex)
        Me.CurrentSession.SetSquareColour(c, square)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CurrentSession = New Session
        Me.AddWallsButt.BackColor = Color.IndianRed
        Me.AddStartPointButt.BackColor = Color.IndianRed
        Me.DrawEndButt.BackColor = Color.IndianRed
    End Sub

    
    Private Sub AddWallsButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddWallsButt.Click
        Me.CurrentSession.DrawIndexCall(0)
        Me.AddWallsButt.BackColor = Color.DarkSeaGreen
        Me.DrawEndButt.BackColor = Color.IndianRed
        Me.AddStartPointButt.BackColor = Color.IndianRed
    End Sub

    Private Sub DrawEndButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawEndButt.Click
        Me.CurrentSession.DrawIndexCall(2)
        Me.AddWallsButt.BackColor = Color.IndianRed
        Me.AddStartPointButt.BackColor = Color.IndianRed
        Me.DrawEndButt.BackColor = Color.DarkSeaGreen
    End Sub

    Private Sub AddStartPointButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddStartPointButt.Click
        Me.CurrentSession.DrawIndexCall(1)
        Me.AddWallsButt.BackColor = Color.IndianRed
        Me.AddStartPointButt.BackColor = Color.DarkSeaGreen
        Me.DrawEndButt.BackColor = Color.IndianRed
    End Sub

    Private Sub FindPathButt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindPathButt.Click
        Me.CurrentSession.createLinkTable()
        Dim dykstras As DykstrasAlgor
        dykstras = New DykstrasAlgor
        dykstras.dykstraV2(Me.CurrentSession.NodesCall, Me.CurrentSession.StartCall, Me.CurrentSession.EndCall)
        dykstras = Nothing
    End Sub

    'Private Sub TextBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseHover
    '    Dim KeyCode As New KeyEventArgs
    '    If KeyCode.KeyValue = KeyCode.KeyCode.A Then
    '        MsgBox("")
    '    End If

    'End Sub


    'Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    MsgBox("")
    'End Sub
End Class
