namespace ProvaArchUnit
{

    using ArchUnitNET.Domain;
    using ArchUnitNET.Loader;
    using ArchUnitNET.Fluent;

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
        private static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(
           System.Reflection.Assembly.Load("CartModule"),
           System.Reflection.Assembly.Load("ProductsModule"),
           System.Reflection.Assembly.Load("PromotionsModule"),
           System.Reflection.Assembly.Load("Website"),
           System.Reflection.Assembly.Load("Common")
       ).Build();

        private readonly IObjectProvider<IType> CartModuleLayer =
                Types()
                .That()
                .ResideInAssembly("CartModule")
                .As("CartModule Layer");
        private readonly IObjectProvider<IType> WebModuleLayer =
              Types()
              .That()
              .ResideInAssembly("Website")
              .As("Web Layer");


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Cart_Should_NotDependOnWeb()
        {
            var cartModuleShouldNotDependOnWebModule = Types().That().Are(CartModuleLayer)
                   .Should()
                   .NotDependOnAny(WebModuleLayer)
                   .WithoutRequiringPositiveResults(); // spiega!

            cartModuleShouldNotDependOnWebModule.Check(Architecture);
            Assert.That(cartModuleShouldNotDependOnWebModule.HasNoViolations(Architecture));
        }


        [Test]
        public void Web_Should_DependOnCart()
        {
            var webShouldDependOnCartModule = Types().That().Are(WebModuleLayer)
                   .Should()
                   .DependOnAny(CartModuleLayer); 

            webShouldDependOnCartModule.Check(Architecture);
            Assert.That(webShouldDependOnCartModule.HasNoViolations(Architecture));

        }

    }

    public class TestsOnClasses
    {

    }

    public class TestsOnInterfaces
    {
    }

    public class TestsOnNamespaces
    {
    }

    public class TestsOnMethods
    {

    }
}
