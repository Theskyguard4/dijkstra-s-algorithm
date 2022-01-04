Public Class Session
    Protected AllNodes(33, 24) As Nodes
    Protected DrawIndex As Integer '0 = walls 1 = start 2 = end 3 = none
    Protected StartP As Form1.NodeIndex
    Protected EndP As Form1.NodeIndex
    Protected FastestRoute As List(Of Form1.NodeIndex)
    Public Sub New()
        For x = 0 To 32
            For y = 0 To 24
                AllNodes(x, y) = New Nodes(x * 25, y * 25, 25, 25, x, y)
            Next
        Next
        Me.StartP.X = -1
        Me.EndP.X = -1
        Me.DrawIndex = 3
    End Sub
    Public Sub SetSquareColour(ByVal c As Color, ByVal square As Form1.NodeIndex)
        Me.AllNodes(square.X, square.Y).SetColour(c)
    End Sub
    Public Sub SetFastestRoute(ByVal FR As List(Of Form1.NodeIndex))
        Me.FastestRoute = FR
    End Sub
    Public Sub SetAsviewed(ByVal InD As Form1.NodeIndex)
        Me.AllNodes(InD.X, InD.Y).SetColour(Color.Orange)
    End Sub
    Public Sub SetAsSearched(ByVal InD As Form1.NodeIndex)
        Me.AllNodes(InD.X, InD.Y).SetColour(Color.Yellow)
    End Sub

    Public Function CheckIfNodeDiscovered(ByVal nID As Form1.NodeIndex)
        Return AllNodes(nID.X, nID.Y).IsSearched

    End Function
    Public Function GetLinkedListOfNode(ByVal nID As Form1.NodeIndex)
        Return AllNodes(nID.X, nID.Y).GetLInkedList
    End Function
    Public Function NodesCall()
        Return Me.AllNodes
    End Function
    Public Sub clearANode(ByVal I As Form1.NodeIndex)
        Me.AllNodes(I.X, I.Y).ResetNode()
    End Sub
    Public Sub ClearStart()
        Me.AllNodes(Me.StartP.X, Me.StartP.Y).ResetNode()
    End Sub
    Public Sub ClearEnd()
        Me.AllNodes(Me.EndP.X, Me.EndP.Y).ResetNode()
    End Sub
    Public Sub DrawIndexCall(ByVal I As Integer)
        Me.DrawIndex = I
    End Sub
    Public Function DrawIndexCall()
        Return Me.DrawIndex
    End Function
    Public Sub StartCall(ByVal point As Form1.NodeIndex)
        Me.StartP = point
    End Sub
    Public Function StartCall()
        Return Me.StartP
    End Function
    Public Sub EndCall(ByVal point As Form1.NodeIndex)
        Me.EndP = point
    End Sub
    Public Function EndCall()
        Return Me.EndP
    End Function
    Public Sub createLinkTable()
        Dim ID As Form1.NodeIndex
        Dim count As Integer = 0
        For x = 0 To 32
            For y = 0 To 24


                Me.AllNodes(x, y).ClearLLList()

                'up
                If y > 0 Then
                    If Me.AllNodes(x, y - 1).Currentstate <> 0 Then
                        ID.X = x
                        ID.Y = y - 1
                        ID.Index = count - 1
                        Me.AllNodes(x, y).AddToLinkList(ID)
                    End If
                End If

                'down
                If y < 24 Then
                    If Me.AllNodes(x, y + 1).Currentstate <> 0 Then
                        ID.X = x
                        ID.Y = y + 1
                        ID.Index = count + 1
                        Me.AllNodes(x, y).AddToLinkList(ID)
                    End If
                End If

                'left
                If x > 0 Then
                    If Me.AllNodes(x - 1, y).Currentstate <> 0 Then
                        ID.X = x - 1
                        ID.Y = y
                        ID.Index = count - 33
                        Me.AllNodes(x, y).AddToLinkList(ID)
                    End If
                End If

                'right
                If x < 32 Then
                    If Me.AllNodes(x + 1, y).Currentstate <> 0 Then
                        ID.X = x + 1
                        ID.Y = y
                        ID.Index = count + 33
                        Me.AllNodes(x, y).AddToLinkList(ID)
                    End If
                End If
                count += 1
            Next
        Next
    End Sub
    Public Function getSingleNode(ByVal nID As Form1.NodeIndex) As Nodes
        Return AllNodes(nID.X, nID.Y)
    End Function
End Class
