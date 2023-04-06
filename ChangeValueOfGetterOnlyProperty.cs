public class MyClass
{
     public int MyNumber {get;}
}

var field = typeof(MyClass).GetField("<MyNumber>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
field.SetValue(anIstanceOfMyClass, 3);

--------

MyTestClass MyClass = new MyTestClass( "Hello" );
FieldInfo MyWriteableField = MyClass.GetType().GetRuntimeFields().Where( a => Regex.IsMatch( a.Name, $"\\A<{nameof( MyClass.MyProperty )}>k__BackingField\\Z" ) ).FirstOrDefault();
MyWriteableField.SetValue( MyClass, "Another new value" );
