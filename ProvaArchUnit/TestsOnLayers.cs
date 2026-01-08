namespace ProvaArchUnit
{

    using ArchUnitNET.Domain;
    using ArchUnitNET.Loader;

    //add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
    using static ArchUnitNET.Fluent.ArchRuleDefinition;
    using ArchUnitNET.NUnit;

    /*
     
     flowchart LR
    A[CartModule]
    B[Common]
    C[Website]
    D[ProductsModule]
    E[PromotionsModule]

    C --> A
    C --> B
    C --> D
    C --> E

    A --> B
    A --> D
    A --> E
     */

    /*
    .  Installa TngTech.ArchUnitNET e TngTech.ArchUnitNET.NUnit da NuGet
    . aggiungi i namespace necessari
    . Focus su CartModule, che non deve aver dipendenze vero Web
    . Aggiungi le dipendenze ai progetti, per avere accesso agli assembly
    . Definisci Architecture, caricando gli assembly
     */

    public class TestsOnLayers
    {
        


        [Test]
        public void ProductModule_Should_NotDependOnPromotions()
        {
            var productsModuleShouldNotDependOnPromotionsModule = Types().That().Are(ArchitectureDefinition.ProductModuleLayer)
                   .Should()
                   .NotDependOnAny(ArchitectureDefinition.PromotionsModuleLayer)
                   .WithoutRequiringPositiveResults(); // spiega!

            productsModuleShouldNotDependOnPromotionsModule.Check(ArchitectureDefinition.Architecture);
            Assert.That(productsModuleShouldNotDependOnPromotionsModule.HasNoViolations(ArchitectureDefinition.Architecture));
        }


        [Test]
        public void Web_Should_DependOnCart()
        {
            var webShouldDependOnCartModule = Types().That().Are(ArchitectureDefinition.WebModuleLayer)
                   .Should()
                   .DependOnAny(ArchitectureDefinition.CartModuleLayer)
                   .WithoutRequiringPositiveResults();

            webShouldDependOnCartModule.Check(ArchitectureDefinition.Architecture);
            Assert.That(webShouldDependOnCartModule.HasNoViolations(ArchitectureDefinition.Architecture));

        }

    }
}
