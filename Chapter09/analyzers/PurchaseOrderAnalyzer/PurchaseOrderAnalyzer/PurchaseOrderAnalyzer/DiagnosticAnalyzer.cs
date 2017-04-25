using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace PurchaseOrderAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PurchaseOrderAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "PurchaseOrderAnalyzer";

        public enum ClassTypesToCheck { PurchaseOrder, SalesOrder }
        public enum MandatoryInterfaces { IReceiptable }

        private static readonly LocalizableString Title = "Interface Implementation Available"; 
        private static readonly LocalizableString MessageFormat = "IReceiptable Interface not Implemented"; 
        private static readonly LocalizableString Description = "You need to implement the IReceiptable interface"; 
        private const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            bool blnInterfaceImplemented = false;
            if (!context.Symbol.IsAbstract)
            {
                var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
                List<string> classesToCheck = Enum.GetNames(typeof(ClassTypesToCheck)).ToList();

                if (classesToCheck.Any(s => s.Equals(namedTypeSymbol.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    string interfaceName = nameof(MandatoryInterfaces.IReceiptable);

                    if (namedTypeSymbol.AllInterfaces.Any(s => s.Name.Equals(interfaceName, StringComparison.OrdinalIgnoreCase)))
                    {
                        blnInterfaceImplemented = true;
                    }

                    if (!blnInterfaceImplemented)
                    {
                        // Produce a diagnostic.
                        var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }
    }
}
