Public Class Nodes
    Protected NodeIndex As Form1.NodeIndex
    Protected Xpos As Integer
    Protected Ypos As Integer
    Protected Width As Integer
    Protected Hieght As Integer
    Protected Visrep As TextBox
    Protected MyCurrentState As Integer ' 0 = wall 1 = start 2 = end 3 = none
    Protected FastestDistance As Integer
    Protected SearchedFull As Boolean
    Protected LinkedNodes As List(Of Form1.NodeIndex)
    Public Sub SetColour(ByVal c As Color)
        Me.Visrep.BackColor = c
    End Sub
    Public Sub New(ByVal X, ByVal Y, ByVal W, ByVal H, ByVal indexX, ByVal indexY)
        Me.NodeIndex = New Form1.NodeIndex
        Me.FastestDistance = 999999
        Me.SearchedFull = False
        Me.LinkedNodes = New List(Of Form1.NodeIndex)
        Me.Visrep = New TextBox
        Me.Xpos = X
        Me.Ypos = Y
        Me.NodeIndex.X = indexX
        Me.NodeIndex.Y = indexY
        Me.MyCurrentState = 3
        Me.Width = W
        Me.Hieght = H

        Me.Visrep.BorderStyle = BorderStyle.FixedSingle
        Me.Visrep.Multiline = True

        Me.Visrep.SetBounds(Xpos, Ypos, Width, Hieght)
        Me.Visrep.BackColor = Color.ForestGreen
        AddHandler Me.Visrep.Click, AddressOf Nodeclick
        Form1.Controls.Add(Visrep)
    End Sub
    Public Sub SetIssearched(ByVal b As Boolean)
        Me.SearchedFull = b
    End Sub

    Private Sub Nodeclick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case Form1.CurrentSession.DrawIndexCall
            Case 0 ' wall
                If Me.MyCurrentState = 3 Then
                    Me.Visrep.BackColor = Color.BlanchedAlmond
                    Me.MyCurrentState = 0
                Else
                    Me.Visrep.BackColor = Color.ForestGreen
                    Me.MyCurrentState = 3

                End If
            Case 1 ' start
                If Me.MyCurrentState = 3 Then
                    Me.Visrep.BackColor = Color.BlueViolet
                    Me.MyCurrentState = 1
                    If Form1.CurrentSession.StartCall.x = -1 Then

                        Form1.CurrentSession.StartCall(Me.NodeIndex)
                    Else
                        Form1.CurrentSession.ClearStart()
                        Form1.CurrentSession.StartCall(Me.NodeIndex)
                    End If

                Else
                    Me.Visrep.BackColor = Color.ForestGreen
                    Dim II As Form1.NodeIndex
                    II.X = -1
                    II.Y = 0
                    If Me.MyCurrentState = 2 Then
                        Form1.CurrentSession.EndCall(II)
                    Else
                        Form1.CurrentSession.StartCall(II)
                    End If
                    Me.MyCurrentState = 3




                End If
            Case 2 ' end
                If Me.MyCurrentState = 3 Then
                    Me.Visrep.BackColor = Color.DarkRed
                    Me.MyCurrentState = 2
                    If Form1.CurrentSession.EndCall.x = -1 Then

                        Form1.CurrentSession.EndCall(Me.NodeIndex)
                    Else
                        Form1.CurrentSession.ClearEnd()
                        Form1.CurrentSession.EndCall(Me.NodeIndex)
                    End If

                Else
                    Me.Visrep.BackColor = Color.ForestGreen

                    Dim II As Form1.NodeIndex
                    II.X = -1
                    II.Y = 0
                    If Me.MyCurrentState = 2 Then
                        Form1.CurrentSession.EndCall(II)
                    Else
                        Form1.CurrentSession.StartCall(II)
                    End If
                    Me.MyCurrentState = 3
                End If
            Case Else

        End Select
    End Sub
    Public Function Currentstate()
        Return Me.MyCurrentState
    End Function
    Public Sub NodePos(ByVal pos As Form1.NodeIndex)
        Me.NodeIndex = pos
    End Sub

    Public Function NodePos()
        Return Me.NodeIndex
    End Function
    Public Sub LinkedNode(ByVal LN As List(Of Form1.NodeIndex))
        Me.LinkedNodes = LN
    End Sub
    Public Function LinkedNode() As List(Of Form1.NodeIndex)
        Return Me.LinkedNodes
    End Function
    Public Sub ResetNode()
        Me.Visrep.BackColor = Color.ForestGreen
        Me.MyCurrentState = 3
    End Sub
    Public Sub AddToLinkList(ByVal Index As Form1.NodeIndex)
        Index.Done = False
        Dim count As Integer = 0
        For x = 0 To 32
            For y = 0 To 24
                If x = Index.X And y = Index.Y Then
                    Index.Index = count

                End If
                count += 1
            Next
        Next
        Me.LinkedNodes.Add(Index)
    End Sub
    Public Sub ClearLLList()
        Me.LinkedNodes.Clear()
    End Sub
    Public Function GetLInkedList() As List(Of Form1.NodeIndex)
        Return Me.LinkedNodes
    End Function
    Public Function IsSearched()
        Return Me.SearchedFull
    End Function
End Class
