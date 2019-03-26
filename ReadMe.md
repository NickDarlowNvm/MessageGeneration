# Message Generation

This prototype explores generation of data classes for messaging between applications. It demonstrates

 1. Use of dependency injection to autowire language specific code generators
 1. Use of a templating library
 1. Generation a hash for each message schema embedded in the generated code

## Dependency Injection

Language specific code generators implement the ILanguageCodeGenerator interface. The constructor for CodeGenerator requires an enumerable of ILanguageCodeGenerator which [Ninject](http://www.ninject.org/) populates with all implementations bound to the interface.

```csharp
public CodeGenerator(IEnumerable<ILanguageCodeGenerator> languageCodeGenerators)
```

Binding is done using ninject.extensions.conventions.

```csharp
kernel.Bind(x => x
    .FromThisAssembly()
    .SelectAllClasses()
    .BindAllInterfaces());
```

## Templating

The [Handlebars.net](https://github.com/rexm/Handlebars.Net) library is used for templating. Templates for generating C# code is found in directory `CsTemplates`.

```
namespace ToDo
{
    public class {{Name}}
    {
		public static readonly string Schema = "{{Schema}}";

		{{#each Properties}}
		public {{Type}} {{Name}} { get; set; }
		{{/each}}
    }
}
```

Message definitions from the Model namespace are decorated to add functionality specific to C# code generation. This is done by classes `CsMessage` and `CsProperty`.

## Schema Hash

The schema hash is calculated in the `CsMessage` decorator constructor.

```csharp
var json = JsonConvert.SerializeObject(message);
var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(json));
Schema = bytes.Select(b => b.ToString("X2")).Aggregate((s1, s2) => s1 + s2);
```

If a `Message` definition changes this will change the hash. If a `Message` includes a property of type `Message` and that type changes the hash of the parent will change.
