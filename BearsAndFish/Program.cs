using BearsAndFish;
Random r = new Random();

Animal?[] CreateRiverFromArray(char[] input)
{
    Animal?[] river = new Animal?[input.Length];

    for (int i = 0; i < input.Length; i++)
    {
        switch (input[i])
        {
            case '_':
                // Null element for underscore
                break;
            case 'f':
                river[i] = new Fish();
                break;
            case 'b':
                river[i] = new Bear();
                break;
        }
    }

    return river;
}



char[] riverConfig = [ 'b', 'f', 'b', '_', 'f', '_', '_', '_', 'f', '_', 'f', 'f', 'f', 'f', 'f', 'b', '_', 'f', '_', 'b' ];
Animal?[] river = CreateRiverFromArray(riverConfig);
while (!AreAllElementsOfSameType(river))
{
    PrintArray(river, out _);
    MoveAllAnimals(river);
}


void PrintArray(Animal?[] animals, out string arrayString)
{
    arrayString = String.Empty;
    foreach (var animal in animals)
    {
        if (animal != null)
        {
            arrayString += animal.GetInitial();
        }
        else
        {
            arrayString += '_';
        }
    }
    Console.WriteLine(arrayString);
}

void MoveAllAnimals(Animal?[] ecosystem)
{
    for (int i = 0; i < ecosystem.Length; i++)
    {
        if (ecosystem[i] != null)
        {
            int move = MoveAnimal(ecosystem, i);
            if (move == 1)
            {
                i++;
            }
        }
    }

    int MoveAnimal(Animal?[] array, int index)
    {
        int[] movements = [-1, 1];
        int movement;
        if (index == 0)
        {
            movement = 1;
        }
        else if (index == array.Length - 1)
        {
            movement = -1;
        }
        else
        {
            movement = movements[r.Next(0, 2)];
        }

        Animal? animal = array[index];
        if (array[index + movement] != null)
        {
            if (animal?.GetType() == array[index + movement]?.GetType() && array.Contains(null))
            {
                if (animal?.GetType() == typeof(Bear))
                {
                    Copulate<Bear>(array);
                    // Console.WriteLine($"Two bears copulated");
                    PrintArray(array, out _);
                    return movement;
                }
                if (animal?.GetType() == typeof(Fish))
                {
                    Copulate<Fish>(array);
                    // Console.WriteLine($"Two fish copulated");
                    PrintArray(array, out _);
                    return movement;
                }
            }
            else
            {
                if (animal?.GetType() == typeof(Bear))
                {
                    array[index + movement] = null;
                    // Console.WriteLine($"I ate a fish at index {index + movement}");
                    // PrintArray(array, out _);
                    return movement;
                }
                if (animal?.GetType() == typeof(Fish))
                {
                    array[index] = null;
                    // Console.WriteLine($"I ate a fish at index {index}");
                    // PrintArray(array, out _);
                    return movement;
                }
            }
        }
        array[index + movement] = animal;
        // Console.WriteLine($"{animal?.GetType()} moved to index {index + movement}");
        array[index] = null;
        return movement;
    }
}

void Copulate<T>(Animal?[] ecosystem) where T : Animal?, new()
{
    List<int> validIndices = new List<int>();
    for (int i = 0; i < ecosystem.Length; i++)
    {
        if (ecosystem[i] == null)
        {
            validIndices.Add(i);
        }
    }

    int spawnIndex = validIndices[r.Next(0, validIndices.Count)];
    ecosystem[spawnIndex] = new T();
}

bool AreAllElementsOfSameType<T>(T[] array)
{
    Type? firstElementType = array[0]?.GetType();

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i]?.GetType() != firstElementType)
        {
            return false;
        }
    }
    return true;
}