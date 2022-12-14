//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Day_11.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Day_11.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Monkey 0:
        ///  Starting items: 75, 63
        ///  Operation: new = old * 3
        ///  Test: divisible by 11
        ///    If true: throw to monkey 7
        ///    If false: throw to monkey 2
        ///
        ///Monkey 1:
        ///  Starting items: 65, 79, 98, 77, 56, 54, 83, 94
        ///  Operation: new = old + 3
        ///  Test: divisible by 2
        ///    If true: throw to monkey 2
        ///    If false: throw to monkey 0
        ///
        ///Monkey 2:
        ///  Starting items: 66
        ///  Operation: new = old + 5
        ///  Test: divisible by 5
        ///    If true: throw to monkey 7
        ///    If false: throw to monkey 5
        ///
        ///Monkey 3:
        ///  Starting i [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Input {
            get {
                return ResourceManager.GetString("Input", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Monkey 0:
        ///  Starting items: 79, 98
        ///  Operation: new = old * 19
        ///  Test: divisible by 23
        ///    If true: throw to monkey 2
        ///    If false: throw to monkey 3
        ///
        ///Monkey 1:
        ///  Starting items: 54, 65, 75, 74
        ///  Operation: new = old + 6
        ///  Test: divisible by 19
        ///    If true: throw to monkey 2
        ///    If false: throw to monkey 0
        ///
        ///Monkey 2:
        ///  Starting items: 79, 60, 97
        ///  Operation: new = old * old
        ///  Test: divisible by 13
        ///    If true: throw to monkey 1
        ///    If false: throw to monkey 3
        ///
        ///Monkey 3:
        ///  Starting item [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TestInput {
            get {
                return ResourceManager.GetString("TestInput", resourceCulture);
            }
        }
    }
}
