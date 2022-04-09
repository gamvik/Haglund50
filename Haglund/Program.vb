Module Program
    Sub Main(args As String())
        ' Sätt fönstertiteln
        Console.Title = "Fredrik 50 år"

        ' Skapa objekt för födelsedagsbarnet
        Dim Fredrik As New Haglund

        ' Säkerställ ålder
        If Fredrik.Age < 50 Then Return

        ' Namn på vännerna
        Dim friends = {"Daniel", "HP", "Jesper G", "Jesper H"}

        ' Skriv ut själva gratulationen
        Console.WriteLine("   _____           _   _   _     _ ")
        Console.WriteLine("  / ____|         | | | | (_)   | |")
        Console.WriteLine(" | |  __ _ __ __ _| |_| |_ _ ___| |")
        Console.WriteLine(" | | |_ | '__/ _` | __| __| / __| |")
        Console.WriteLine(" | |__| | | | (_| | |_| |_| \__ \_|")
        Console.WriteLine("  \_____|_|  \__,_|\__|\__|_|___(_)")
        Console.WriteLine()
        Console.WriteLine(New String("-", Console.BufferWidth))
        Console.WriteLine()
        Console.WriteLine($"Stort grattis på din 50-årsdag {NameOf(Fredrik)} önskar {String.Join(", ", friends)}!")
        Console.WriteLine()

        ' Hämta presenten
        Dim present As Dinner = GetPresent(Fredrik)

        ' Se till att presenten passar
        If present Is Nothing Then
            Return
        End If

        ' Skriv ut information om presenten
        Console.WriteLine(New String("-", Console.BufferWidth))
        Console.WriteLine()
        Console.WriteLine($"Vi ser fram emot vår gemensamma middag på ""{present.Restaurant.Name}"" {present.PreferredDate.ToLongDateString}!")
        Console.WriteLine("Hör av dig med önskemål om restaurang och datum enligt ovan när du önskar vårt sällskap.")
        Console.WriteLine()

        ' Pausa
        Console.ReadKey()
    End Sub

    Function GetPresent(Fredrik As Haglund) As BirthdayPresent
        ' Kontrollera så personen gillar det vi vill erbjuda
        If Not Fredrik.Likes.HasFlag(Things.Food Or Things.Friends) Then Return Nothing

        ' Överräck presenten
        Console.WriteLine("Vi vill gärna bjuda dig på middag på en av följande restauranger vid en tidpunkt du själv väljer.")
        Console.WriteLine()

        ' Skapa listan med restaurangalternativ
        Dim possibleRestaurants As New List(Of Restaurant) From {
            New Restaurant("Konstnärsbaren KB"),
            New Restaurant("Operabaren"),
            New Restaurant("Tennstopet"),
            New Restaurant("Wärdshuset Ulla Winbladh")
        }

        ' Skriv ut restaurangalternativ
        For Each r In possibleRestaurants
            Console.WriteLine(r.Name)
        Next
        Console.WriteLine()

RestaurantSelection:
        ' Skriv ut text
        Console.WriteLine("Ange första bokstaven i vald restaurangs namn:")

        ' Fråga efter och välj restaurang
        Dim input = Console.ReadLine
        Dim selectedRestaurant = possibleRestaurants.FirstOrDefault(Function(x) x.Name.StartsWith(input, StringComparison.OrdinalIgnoreCase))
        If selectedRestaurant Is Nothing Then
            GoTo RestaurantSelection
        End If
        Console.WriteLine()

DateSelection:
        ' Skriv ut test
        Console.WriteLine("Ange önskat datum (tänk på att vi behöver några veckors framförhållning):")

        ' Fråga efter och parsa datum
        Dim selectedDate As Date
        If Not Date.TryParse(Console.ReadLine, selectedDate) Then
            GoTo DateSelection
        End If
        Console.WriteLine()

        ' Returnera presenten
        Return New Dinner With {.Restaurant = selectedRestaurant, .PreferredDate = selectedDate}
    End Function
End Module