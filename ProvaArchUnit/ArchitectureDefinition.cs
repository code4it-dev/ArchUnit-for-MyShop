namespace ProvaArchUnit
{
    using ArchUnitNET.Domain;
    using ArchUnitNET.Loader;

    //add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
    using static ArchUnitNET.Fluent.ArchRuleDefinition;

    public static class ArchitectureDefinition
    {

        public static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(
               System.Reflection.Assembly.Load("CartModule"),
               System.Reflection.Assembly.Load("ProductsModule"),
               System.Reflection.Assembly.Load("PromotionsModule"),
               System.Reflection.Assembly.Load("Website"),
               System.Reflection.Assembly.Load("Common")
           ).Build();

        public static readonly IObjectProvider<IType> CartModuleLayer =
                Types()
                .That()
                .ResideInAssembly("CartModule")
                .As("CartModule Layer");
        public static readonly IObjectProvider<IType> WebModuleLayer =
              Types()
              .That()
              .ResideInAssembly("Website")
              .As("Web Layer");

        public static readonly IObjectProvider<IType> ProductModuleLayer =
            Types()
            .That()
            .ResideInAssembly("ProductsModule")
            .As("Product Layer");


        public static readonly IObjectProvider<IType> PromotionsModuleLayer =
          Types()
          .That()
          .ResideInAssembly("PromotionsModule")
          .As("Promotions Layer");

    }
}
