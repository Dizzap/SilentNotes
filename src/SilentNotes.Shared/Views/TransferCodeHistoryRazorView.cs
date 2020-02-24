#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SilentNotes.Views
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "TransferCodeHistoryRazorView.cshtml"
using SilentNotes.ViewModels;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "16.4.0.311")]
public partial class TransferCodeHistoryRazorView : TransferCodeHistoryRazorViewBase
{

#line hidden

#line 2 "TransferCodeHistoryRazorView.cshtml"
public TransferCodeHistoryViewModel Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(" />\r\n    <base");

WriteAttribute ("href", " href=\"", "\""

#line 7 "TransferCodeHistoryRazorView.cshtml"
, Tuple.Create<string,object,bool> ("", Model.HtmlBase

#line default
#line hidden
, false)
);
WriteLiteral(">\r\n    <title>SilentNotes</title>\r\n    <meta");

WriteLiteral(" charset=\"UTF-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1, shrink-to-fit=no, user-scalable=no" +
"\"");

WriteLiteral(">\r\n\r\n    <link");

WriteLiteral(" href=\"bootstrap.min.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteLiteral(" href=\"silentnotes.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute ("href", " href=\"", "\""

#line 14 "TransferCodeHistoryRazorView.cshtml"
, Tuple.Create<string,object,bool> ("", Model.Theme.DarkMode ? "silentnotes.dark.css" : "silentnotes.light.css"

#line default
#line hidden
, false)
);
WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n\r\n    <script");

WriteLiteral(" src=\"jquery-3.4.1.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"bootstrap.bundle.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"silentnotes.js\"");

WriteLiteral("></script>\r\n\r\n    <style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">
        .background-icon {
            width: 260px;
            height: 260px;
            right: 0;
            top: -50px;
        }

        .code {
            display: inline-block;
            padding: 0.1em 1em;
            background-color: steelblue;
            color: white;
            font-family: Consolas;
            font-size: 28px;
            text-align: center;
        }
    </style>
    <script>
        $(function () {
            addShortcuts();
        });
    </script>
</head>
<body>
    <nav");

WriteLiteral(" id=\"navigation\"");

WriteLiteral(" class=\"d-flex\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" class=\"nav-item mr-auto shortcut-escape\"");

WriteLiteral(" onclick=\"bind(event);\"");

WriteLiteral(" data-binding=\"GoBack\"");

WriteAttribute ("title", " title=\"", "\""

#line 46 "TransferCodeHistoryRazorView.cshtml"
                                                                      , Tuple.Create<string,object,bool> ("", Model.Language["back"]

#line default
#line hidden
, false)
);
WriteLiteral(">");


#line 46 "TransferCodeHistoryRazorView.cshtml"
                                                                                                                                        WriteLiteral(Model.Icon["arrow-left"]);

#line default
#line hidden
WriteLiteral("</button>\r\n    </nav>\r\n\r\n    <div");

WriteLiteral(" id=\"content\"");

WriteLiteral(" class=\"container-fluid p-4\"");

WriteLiteral(">\r\n        <svg");

WriteLiteral(" class=\"background-icon\"");

WriteLiteral(" width=\'24\'");

WriteLiteral(" height=\'24\'");

WriteLiteral(" viewBox=\'0 0 24 24\'");

WriteLiteral("><use");

WriteLiteral(" xlink:href=\"#svg-key\"");

WriteLiteral(" /></svg>\r\n\r\n        <h1>");


#line 52 "TransferCodeHistoryRazorView.cshtml"
       Write(Model.Language["transfer_code"]);


#line default
#line hidden
WriteLiteral("</h1>\r\n\r\n");


#line 54 "TransferCodeHistoryRazorView.cshtml"
        

#line default
#line hidden

#line 54 "TransferCodeHistoryRazorView.cshtml"
         if (@Model.TransferCodeFmt == "")
        {


#line default
#line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"alert alert-success my-4\"");

WriteLiteral(">");


#line 56 "TransferCodeHistoryRazorView.cshtml"
                                             Write(Model.Language["transfer_not_existing"]);


#line default
#line hidden
WriteLiteral("</div>\r\n");


#line 57 "TransferCodeHistoryRazorView.cshtml"
        }
        else
        {


#line default
#line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"my-1\"");

WriteLiteral(">");


#line 60 "TransferCodeHistoryRazorView.cshtml"
                         Write(Model.Language["transfer_code_usage"]);


#line default
#line hidden
WriteLiteral("</div>\r\n");


#line 61 "TransferCodeHistoryRazorView.cshtml"



#line default
#line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"code my-4\"");

WriteLiteral(">");


#line 63 "TransferCodeHistoryRazorView.cshtml"
                                  Write(Model.TransferCodeFmt);


#line default
#line hidden
WriteLiteral("</div>\r\n            </div>\r\n");


#line 65 "TransferCodeHistoryRazorView.cshtml"



#line default
#line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"my-1\"");

WriteLiteral(">");


#line 66 "TransferCodeHistoryRazorView.cshtml"
                         Write(Model.Language["transfer_code_writedown"]);


#line default
#line hidden
WriteLiteral("</div>\r\n");


#line 67 "TransferCodeHistoryRazorView.cshtml"



#line default
#line hidden
WriteLiteral("            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-secondary my-4\"");

WriteLiteral(" onclick=\"bind(event)\"");

WriteLiteral(" data-binding=\"ShowTransfercodeHistoryCommand\"");

WriteLiteral(">");


#line 68 "TransferCodeHistoryRazorView.cshtml"
                                                                                                                                Write(Model.Language["transfer_code_show_history"]);


#line default
#line hidden
WriteLiteral("</button>\r\n");


#line 69 "TransferCodeHistoryRazorView.cshtml"



#line default
#line hidden
WriteLiteral("            <ul");

WriteLiteral(" class=\"list-group col-9\"");

WriteLiteral(" data-binding=\"TransfercodeHistory\"");

WriteLiteral(">\r\n");


#line 71 "TransferCodeHistoryRazorView.cshtml"
                

#line default
#line hidden

#line 71 "TransferCodeHistoryRazorView.cshtml"
                 foreach (var historyEntry in @Model.TransferCodeHistory)
                {


#line default
#line hidden
WriteLiteral("                    <li");

WriteLiteral(" class=\"list-group-item list-group-item-secondary\"");

WriteLiteral(">");


#line 73 "TransferCodeHistoryRazorView.cshtml"
                                                                     Write(historyEntry);


#line default
#line hidden
WriteLiteral("</li>\r\n");


#line 74 "TransferCodeHistoryRazorView.cshtml"
                }


#line default
#line hidden
WriteLiteral("            </ul>\r\n");


#line 76 "TransferCodeHistoryRazorView.cshtml"
        }


#line default
#line hidden
WriteLiteral("    </div>\r\n\r\n    <div hidden>\r\n");


#line 80 "TransferCodeHistoryRazorView.cshtml"
        

#line default
#line hidden

#line 80 "TransferCodeHistoryRazorView.cshtml"
          WriteLiteral(Model.Icon.LoadIcon("key", new[] { new KeyValuePair<string, string>("id", "svg-key") }));

#line default
#line hidden
WriteLiteral("\r\n    </div>\r\n</body>\r\n</html>\r\n");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class TransferCodeHistoryRazorViewBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591
