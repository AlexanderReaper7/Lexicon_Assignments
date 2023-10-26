namespace LexiconPractice3;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            PersonHandler personHandler = new PersonHandler();

            Person person1 = personHandler.CreatePerson(25, "John", "Doe", 180, 75);
            Console.WriteLine("Person 1:");
            Console.WriteLine($"Name: {person1.FName} {person1.LName}");
            Console.WriteLine($"Age: {person1.Age}");
            Console.WriteLine($"Height: {person1.Height}");
            Console.WriteLine($"Weight: {person1.Weight}");
            Console.WriteLine();
            // använd PersonHandler´s metoder för att ändra personens egenskaper
            personHandler.SetAge(person1, 30);
            Console.WriteLine($"Age: {person1.Age}");

            Person _ = personHandler.CreatePerson(0, "Anna", "Smith", 160, 50); // Age validering misslyckas och ArgumentException kastas
        }
        catch (ArgumentException ex)
        {
            // Nås När "Anna" skapas
            Console.WriteLine($"Error: {ex.Message}");
        }

        List<UserError> errors = new List<UserError>
        {
            new NumericInputError(),
            new TextInputError(),
            new CustomError("This is a custom error message"),
            new CustomError("Another custom error message")
        };

        // Skriver ut meddelanden från UserErrors
        foreach (var error in errors)
        {
            Console.WriteLine(error.UEMessage());
        }

        List<Animal> animals = new List<Animal>
        {
            new Horse("Horse1", 500, 5),
            new Dog("Dog1", 20, 3),
            new Hedgehog("Hedgehog1", 1, 1),
            new Worm("Worm1", 0.01, 1),
            new Bird("Bird1", 0.1, 1),
            new Wolf("Wolf1", 50, 7)
        };

        // Skriver ut information om djur
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Stats());
            // 13. F: Förklara vad det är som händer
            // I varje steg i arvet så läggs en ny Stats() metod till som skriver ut information om bas klassen och all i kedjan av arv
            animal.DoSound();

            if (animal is IPerson person)
            {
                Console.WriteLine(person.Talk());
            }
        }

        List<Dog> dogs = new List<Dog>
        {
            new Dog("Dog2", 25, 4),
            new Dog("Dog3", 30, 5)
        };
        // 9 F: Försök att lägga till en häst i listan av hundar. Varför fungerar inte det?
        // dogs.Add(new Horse("Horse2", 400, 4)); // Det går inte att lägga till en häst i listan av hundar eftersom Horse inte ärver från Dog
        // 10. F: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?
        // List<Animal> animals = new List<Animal>(); // Listan måste vara av typen Animal för att alla klasser ska kunna lagras tillsammans
        // Skriver ut information om hundar
        foreach (var animal in animals)
        {
            if (animal is Dog dog)
            {
                Console.WriteLine(dog.Stats());
                Console.WriteLine(dog.CustomMethod());
            }
        }
        // 17. F: skapa en metod i Dog, Kommer du åt den metoden från Animals listan? Varför inte?
        // Nej, det går inte att komma åt metoden från Animals listan eftersom Animals listan är av typen Animal och inte Dog
        // Om en specific instans av Animal är Dog så behöver casta om Animal till Dog för att komma åt metoden
    }
}