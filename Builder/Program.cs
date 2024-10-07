
class Program
    {
        static void Main(string[] args)
        {
            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var director = new Diretor();
            var builder = new ProductBuilder();
            director.Builder = builder;
            
            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListPart());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListPart());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom product:");
            builder.ParteA();
            builder.ParteB();
            Console.Write(builder.GetProduct().ListPart());
        }
    }



public interface IBuilder {
    void ParteA();
    void ParteB();
    void ParteC();
}
public class ProductBuilder : IBuilder
{
    private Product _product = new Product();
    public ProductBuilder(){
        this.Reset();
    }
    public void Reset(){
        _product = new Product();
    }

    public void ParteA()
    {
        this._product.Add("Parte A");
    }

    public void ParteB()
    {
        this._product.Add("Parte B");
    }

    public void ParteC()
    {
        this._product.Add("Parte C");
    }

    public Product GetProduct(){
        Product result = this._product;
        this.Reset();
        return result;
    }
}
public class Product {
    private List<object> _parts = new List<object>();
    public void Add(string part){
        this._parts.Add(part);
    }
    public string ListPart(){
        string str = string.Empty;
        for(int i = 0; i< this._parts.Count; i++){
            str += this._parts[i] + ", ";
        }
        str = str.Remove(str.Length - 2);
        return $"Product parts: {str} \n";
    }
}
public class Diretor {
     private IBuilder? _builder;
        
        public IBuilder Builder
        {
            set { _builder = value; } 
        }
        
        public void BuildMinimalViableProduct()
        {
            this._builder.ParteA();
        }
        
        public void BuildFullFeaturedProduct()
        {
            this._builder.ParteA();
            this._builder.ParteB();
            this._builder.ParteC();
        }
}
