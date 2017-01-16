Module Sample

    Private Class SomethingClass
        Public Property Prop1 As String
        Public Property Prop2 As String
        Public Property Prop3 As String
        Public Property Prop4 As String
        Public Property Prop5 As String
    End Class

    Private aClass As New SomethingClass() With {
        .Prop1 = String.Empty,
        .Prop2 = "A - Prop2",
        .Prop3 = "A - Prop3",
        .Prop4 = "A - Prop4",
        .Prop5 = "A - Prop5"
    }

    Private bClass As New SomethingClass() With {
        .Prop1 = "B - Prop1",
        .Prop2 = "B - Prop2",
        .Prop3 = "B - Prop3",
        .Prop4 = "B - Prop4",
        .Prop5 = "B - Prop5"
    }

    Private Function MergeBtoA()
        Dim merger As New PropertyMerger(GetType(SomethingClass))
        With merger
            .SetField({"Prop1", "Prop3", "Prop5"})
            .SetTarget(aClass)
            .SetData(bClass)
            .Merge()
        End With
        Return merger.GetMergeData()
    End Function

    Sub Main()
        MergeBtoA()
        Console.WriteLine("Merged - Prop1 : " + MergeBtoA().Prop1)
        Console.WriteLine("Merged - Prop2 : " + MergeBtoA().Prop2)
        Console.WriteLine("Merged - Prop3 : " + MergeBtoA().Prop3)
        Console.WriteLine("Merged - Prop4 : " + MergeBtoA().Prop4)
        Console.WriteLine("Merged - Prop5 : " + MergeBtoA().Prop5)
        Console.ReadKey()
    End Sub

End Module
