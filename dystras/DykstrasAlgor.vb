Public Class DykstrasAlgor
    Protected SearchedNodes As List(Of Form1.NodeIndex)
    Protected AllNodes As List(Of Nodes)
    Protected NodeIndex As List(Of Integer)
    Public Function GetShortestpath(ByVal all_nodes_array(,) As Nodes, ByVal StartPos As Form1.NodeIndex, ByVal EndPos As Form1.NodeIndex)
        MsgBox(StartDyktras(all_nodes_array, StartPos, EndPos))
    End Function

    Public Function StartDyktras(ByVal all_nodes_array(,) As Nodes, ByVal StartPos As Form1.NodeIndex, ByVal EndPos As Form1.NodeIndex)
        AllNodes = New List(Of Nodes)
        NodeIndex = New List(Of Integer)
        Dim count As Integer = 0
        Dim startNodeIndex As Integer
        Dim endNodeIndex As Integer
        Dim Distance(99999) As Integer
        Dim Index As Integer = 0
        Dim PreviousNode(99999) As Integer
        Dim AQueue As New List(Of Integer)
        Dim shortestinqueue As Integer
        Dim shortestinqueuedis As Integer
        Dim currentNode As Integer
        For x = 0 To 32
            For y = 0 To 24
                If x = StartPos.X And y = StartPos.Y Then
                    startNodeIndex = Index
                End If
                If x = EndPos.X And y = EndPos.Y Then
                    endNodeIndex = Index
                End If
                Distance(Index) = 999999
                PreviousNode(Index) = -1
                AQueue.Add(Index)
                AllNodes.Add(all_nodes_array(x, y))
                Index += 1
            Next
        Next
        Dim disSave As Integer
        Distance(startNodeIndex) = 0
        Dim Shortestpath As String
        Dim removeat As Integer
        Do Until AQueue.Count = 0
            shortestinqueuedis = 9999999
            For Vertex = 0 To AQueue.Count - 1
                If Distance(AQueue(Vertex)) <= shortestinqueuedis Then
                    shortestinqueuedis = Distance(AQueue(Vertex))
                    shortestinqueue = AQueue(Vertex)
                    removeat = Vertex
                End If
            Next

            AQueue.RemoveAt(removeat)
            currentNode = shortestinqueue
            Form1.CurrentSession.SetAsSearched(AllNodes(currentNode).NodePos)
            AllNodes(currentNode).SetIssearched(True)
            If currentNode = endNodeIndex Then

                If PreviousNode(endNodeIndex) <> -1 Then
                    Do Until currentNode = -1
                        Shortestpath &= Str(currentNode)
                        currentNode = PreviousNode(currentNode)

                    Loop
                End If
                Return Shortestpath
            End If

            For Each LinkedNode In AllNodes(currentNode).GetLInkedList
                Form1.CurrentSession.SetAsviewed(LinkedNode)
                If AllNodes(LinkedNode.Index).IsSearched = False Then
                    disSave = Distance(currentNode) + 1
                    If disSave < Distance(LinkedNode.Index) Then
                        Distance(LinkedNode.Index) = disSave
                        PreviousNode(LinkedNode.Index) = currentNode
                    End If
                    Form1.CurrentSession.SetAsviewed(LinkedNode)
                Else
                    Form1.CurrentSession.SetAsSearched(LinkedNode)
                End If
            Next


        Loop


    End Function
    Public Function dykstraV2(ByVal all_nodes_array(,) As Nodes, ByVal StartPos As Form1.NodeIndex, ByVal EndPos As Form1.NodeIndex)
        AllNodes = New List(Of Nodes)
        NodeIndex = New List(Of Integer)
        Dim count As Integer = 0
        Dim startNodeIndex As Integer
        Dim endNodeIndex As Integer
        Dim Distance(99999) As Integer
        Dim Index As Integer = 0
        Dim PreviousNode(99999) As Integer
        Dim AQueue As New List(Of Integer)
        Dim shortestinqueue As Integer
        Dim shortestinqueuedis As Integer
        Dim currentNode As Integer
        Dim UnvistedList As New List(Of Form1.DysList)
        Dim VisitedList As New List(Of Form1.DysList)
        Dim tempListEntry As Form1.DysList
        Dim Shortestpath As String = ""


        For x = 0 To 32
            For y = 0 To 24
                tempListEntry.Distance = 9999999
                tempListEntry.previous = Nothing
                tempListEntry.NodeIndexINT = count
                If x = StartPos.X And y = StartPos.Y Then
                    tempListEntry.Distance = 0
                    StartPos.Index = count

                End If
                If x = EndPos.X And y = EndPos.Y Then
                    EndPos.Index = count
                End If
                UnvistedList.Add(tempListEntry)
                AllNodes.Add(all_nodes_array(x, y))
                count += 1
            Next
        Next
     
        Dim TempDis As Integer
        Dim finished As Boolean = False
        Dim unvistedlistcount As Integer = UnvistedList.Count - 1
        Do While finished = False
            If unvistedlistcount = 0 Then
                finished = True
            Else
                currentNode = GetLowestDistance(UnvistedList)
                For Each NeiboringNode In AllNodes(currentNode).LinkedNode
                    If SearchvisitedList(VisitedList, NeiboringNode.Index) = False Then
                        TempDis = UnvistedList(currentNode).Distance + 1
                        If TempDis < UnvistedList(NeiboringNode.Index).Distance Then
                            tempListEntry.NodeIndexINT = UnvistedList(NeiboringNode.Index).NodeIndexINT
                            tempListEntry.NodeIndex2DArray = UnvistedList(NeiboringNode.Index).NodeIndex2DArray
                            tempListEntry.Distance = TempDis
                            tempListEntry.previous = currentNode
                            UnvistedList.Item(NeiboringNode.Index) = tempListEntry

                        End If
                    End If


                Next
                VisitedList.Add(UnvistedList(currentNode))
                If currentNode <> StartPos.Index And currentNode <> EndPos.Index Then
                    Form1.CurrentSession.SetAsviewed(AllNodes(currentNode).NodePos)
                End If

                Threading.Thread.Sleep(10)
                Application.DoEvents()
                tempListEntry = UnvistedList(currentNode)
                tempListEntry.Distance = 9999999
                UnvistedList.Item(currentNode) = tempListEntry
                unvistedlistcount -= 1
                If currentNode = EndPos.Index Then
                    Dim shortpath As New List(Of Integer)
                    Do Until currentNode = StartPos.Index
                        shortpath.Add(VisitedList(FindIndexInList(VisitedList, currentNode)).previous)
                        currentNode = VisitedList(FindIndexInList(VisitedList, currentNode)).previous
                    Loop
                    Dim temp As Form1.NodeIndex
                    Dim counter As Integer = 0
                    Dim ShortPathNodeIndex As New List(Of Form1.NodeIndex)
                    For Each Node In shortpath
                        counter = 0
                        For x = 0 To 32
                            For y = 0 To 24
                                If counter = Node And Node <> EndPos.Index And Node <> StartPos.Index Then
                                    temp.X = x
                                    temp.Y = y
                                    Form1.CurrentSession.SetAsSearched(temp)
                                    ShortPathNodeIndex.Add(temp)
                                    Application.DoEvents()
                                    Threading.Thread.Sleep(30)
                                End If
                                counter += 1
                            Next
                        Next
                    Next
                    Threading.Thread.Sleep(40)
                    For looper = ShortPathNodeIndex.Count - 1 To 0 Step -1
                        Threading.Thread.Sleep(40)
                        Application.DoEvents()
                        If ShortPathNodeIndex(looper).X = EndPos.X And ShortPathNodeIndex(looper).Y = EndPos.Y Or ShortPathNodeIndex(looper).X = StartPos.X And ShortPathNodeIndex(looper).Y = StartPos.Y Then
                        Else
                            Form1.CurrentSession.SetSquareColour(Color.Black, ShortPathNodeIndex(looper))
                        End If

                    Next
                    Return ShortPathNodeIndex
                End If

            End If
        Loop
        'Dim current As Form1.DysList
        'Dim path As String
        'Dim previous
        'For Each Nodes In VisitedList
        '    If Nodes.NodeIndexINT <> StartPos.Index Then
        '        current = Nodes
        '        path = Str(current.NodeIndexINT)
        '        Do Until current.NodeIndexINT = StartPos.Index Or current.NodeIndexINT = 0
        '            previous = VisitedList(current.NodeIndexINT).previous
        '            path = path & " " & Str(previous)
        '            current.NodeIndexINT = VisitedList(current.NodeIndexINT).previous

        '        Loop
        '        If Nodes.NodeIndexINT = StartPos.Index Then
        '            MsgBox(path)
        '        End If
        '    End If

        'Next
        Return VisitedList

    End Function
    Private Function FindIndexInList(ByVal visited As List(Of Form1.DysList), ByVal index As Integer)
        For looper = 0 To visited.Count - 1
            If visited(looper).NodeIndexINT = index Then
                Return looper
            End If
        Next

    End Function

    Private Function GetLowestDistance(ByVal UnvisitedList As List(Of Form1.DysList))
        Dim indexlow As Integer
        Dim smallestINT As Integer = 9999999

        For looper = 0 To UnvisitedList.Count - 1
            If UnvisitedList(looper).Distance < smallestINT Then
                smallestINT = UnvisitedList(looper).Distance
                indexlow = looper
            End If
        Next
        Return indexlow
    End Function
    Private Function SearchvisitedList(ByVal visitedList As List(Of Form1.DysList), ByVal node As Integer)
        For Each nodes In visitedList
            If nodes.NodeIndexINT = node Then
                Return True
            End If


        Next
        Return False
    End Function
End Class
