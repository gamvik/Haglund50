Class Haglund
    ReadOnly Property Age As Integer = 50
    ReadOnly Property Likes As Things = Things.Food Or Things.Friends
End Class

MustInherit Class BirthdayPresent
End Class

Class Dinner
    Inherits BirthdayPresent

    Property Restaurant As Restaurant
    Property PreferredDate As Date
End Class

Class Restaurant
    Sub New(name As String)
        Me.Name = name
    End Sub

    ReadOnly Property Name As String
End Class

Enum Things
    Food
    Friends
End Enum