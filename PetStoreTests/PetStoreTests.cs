using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Services;
using PetStore.Models;
using System.Collections.Generic;

namespace PetStoreTests
{
    [TestClass]
    public class PetStoreTests
    {
        [TestMethod]
        public void GetPet_WithInvalidURI()
        {
            var petService = new PetService("http://fakeurl.com");
            var petList = petService.GetPetByStatus(PetService.statusEnum.available);
            List<Pet> expected = null;

            Assert.AreEqual(expected, petList);
        }

        [TestMethod]
        public void GetPet_WithValidURI()
        {
            var petService = new PetService("https://petstore.swagger.io/v2/pet/");
            var petList = petService.GetPetByStatus(PetService.statusEnum.available);
            List<Pet> expected = null;

            Assert.AreNotEqual(expected, petList);
        }
    }
}
