using PetStore.Models;
using PetStore.Services;
using System;
using System.Linq;

namespace PetStore
{
    class Program
    {
        const string apiUri = "https://petstore.swagger.io/v2/pet/";

        static void Main(string[] args)
        {
            try
            {
                var petService = new PetService(apiUri);

                var petsList = petService.GetPetByStatus(PetService.statusEnum.available);
                if (petsList != null && petsList.Count > 0)
                {
                    petsList = petsList.OrderBy(x => x.category?.name).ThenByDescending(y => y.name).ToList();

                    foreach (Pet pet in petsList)
                    {
                        Console.WriteLine($"Pet Category: {pet.category?.name} \t Pet Name: {pet.name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting available pets from petStore. Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
