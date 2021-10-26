using DesignPatterns.Creational;
using System;
using static DesignPatterns.Behavioral.ChainOfResponsibility;
using static DesignPatterns.Behavioral.Command;
using static DesignPatterns.Behavioral.Iterator;
using static DesignPatterns.Behavioral.Mediator;
using static DesignPatterns.Behavioral.Memento;
using static DesignPatterns.Behavioral.Observer;
using static DesignPatterns.Behavioral.State;
using static DesignPatterns.Behavioral.Strategy;
using static DesignPatterns.Behavioral.TemplateMethod;
using static DesignPatterns.Behavioral.Visitor;
using static DesignPatterns.Creational.AbstractFactory;
using static DesignPatterns.Creational.Builder;
using static DesignPatterns.Creational.FactoryMethod;
using static DesignPatterns.Creational.Prototype;
using static DesignPatterns.Structural.Adapter;
using static DesignPatterns.Structural.Bridge;
using static DesignPatterns.Structural.Composite;
using static DesignPatterns.Structural.Decorator;
using static DesignPatterns.Structural.Facade;
using static DesignPatterns.Structural.Proxy;
using static DesignPatterns.Structural_Patterns.Flyweight;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Creational patterns (Factory method, Abstract factory, Builder, Prototype, Singleton)

                #region Factory Method

                    Separation("---------------FACTORY METHOD----------------------------");

                    var car = FactoryMethodClient.CreateTransport(new CarFactory());
                    var track = FactoryMethodClient.CreateTransport(new TrackFactory());
                    var bus = FactoryMethodClient.CreateTransport(new BusFactory());

                    Console.WriteLine($"Bus - { bus.Drive() }");
                    Console.WriteLine($"Car - { car.Drive() }");
                    Console.WriteLine($"Track - { track.Drive() }");

                #endregion

                #region Abstract factory

                    Separation("---------------ABSTRACT FACTORY----------------------------");

                    var factory = AbstractFactoryClient.CreateOldFurbitureFactory();
                    var chair = factory.CreateChair();
                    var sofa = factory.CreateSofa();
                    var wardrobe = factory.CreateWardrobe();
                    Console.WriteLine($"Chair - { chair.Appearance() }: { chair.Behaviour() }");
                    Console.WriteLine($"Sofa - { sofa.Appearance() }: { sofa.Behaviour() }");
                    Console.WriteLine($"Wardrobe - { wardrobe.Appearance() }: { wardrobe.Behaviour() }");

            #endregion

                #region Builder

                    Separation("---------------BUILDER----------------------------");

                    var builder = new BuildingBuilder();
                    var building = builder.SetId(1).SetName("Office").SetWall("wooden").SetWindow("Glass").Build();
                    Console.WriteLine($"Buiding - { building.Id }: { building.Name}: { building.Wall}: { building.Window }");

                    // with manager
                    var manager = new BuilderManager();
                    building = manager.CreateCheapBuilding();
                    Console.WriteLine($"Buiding - { building.Id }: { building.Name}: { building.Wall}: { building.Window }");

            #endregion

                #region Prototype

                    Separation("---------------PROTOTYPE----------------------------");

                    var robot = new Robot("New model");
                    robot.Description.Weight = 1;
                    var robotNew = robot.DeepClone();
                    robotNew.Description.Weight = 8;
                    Console.WriteLine($"Robot - { robot.Description.Weight }");
                    Console.WriteLine($"New Robot - { robotNew.Description.Weight }");

                #endregion

                #region Singleton

                    Separation("---------------SINGLETON----------------------------");

                    var single = Singleton.Instance;
                    var singleNew = Singleton.Instance;
                    Console.WriteLine($"Singleton - { single.GetHashCode() }, New Singleton - { single.GetHashCode() }. Is equal - { single.GetHashCode() == singleNew.GetHashCode() }");

            #endregion

            #endregion

            #region Structural patterns (Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy)

                #region Adapter

                    Separation("---------------ADAPTER----------------------------");

                    IAdapter adapter = new XMLAdapter(new XMLConverter());
                    var converted = adapter.Convert("4");
                    var saved = adapter.Save("7");
                    Console.WriteLine(converted);
                    Console.WriteLine(saved);

                #endregion

                #region Bridge

                    Separation("---------------BRIDGE----------------------------");

                    var blueSquare = new Square(new BlueColor());
                    var redSquare = new Square(new RedColor());
                    Console.WriteLine(blueSquare.Display());
                    Console.WriteLine(redSquare.Display());

                #endregion

                #region Composite

                    Separation("---------------COMPOSITE----------------------------");

                    var bread = new Bread();
                    var milk = new Milk();
                    var box = new Box();
                    box.Add(milk);
                    box.Add(bread);
                    var newBox = new Box();
                    newBox.Add(bread);
                    newBox.Add(box);

                    Console.WriteLine($"Milk costs { milk.GetPrice() }");
                    Console.WriteLine($"Bread costs { bread.GetPrice() }");
                    Console.WriteLine($"Total Price (box) is { box.GetPrice() }");
                    Console.WriteLine($"Total Price (newBox) is { newBox.GetPrice() }");

                #endregion

                #region Decorator

                    Separation("---------------DECORATOR----------------------------");

                    var decorator = new BasicNotifierWrapper(new EmailNotifier());
                    var additionalDecorator = new AlarmNotifierWrapper(decorator, new SmsNotifier());

                    Console.WriteLine($"Decorator - { decorator.Notify() }");
                    Console.WriteLine($"Decorator from another Decorator - { additionalDecorator.Notify() }");

                #endregion

                #region Facade

                    Separation("---------------FACADE----------------------------");

                    IFacade facade = new MovieFacade(new ExternalMovie());

                    Console.WriteLine(facade.Render("txt"));

                #endregion

                #region Flyweight

                    Separation("---------------FLYWEIGHT----------------------------");

                    var weapon = new Weapon(WeaponType.Gun);
                    weapon.Position.X = 10;
                    weapon.Position.Y = 15;

                    var newWeapon = new Weapon(WeaponType.Gun);

                    Console.WriteLine($"Weapon view - {weapon.View.Image}, New Weapon view - {newWeapon.View.Image}; Equal - {weapon.View.GetHashCode() == weapon.View.GetHashCode()} ");

                #endregion

                #region Proxy

                    Separation("---------------PROXY----------------------------");

                    IDatabase db = new DatabaseProxy(new MySql());
                    Console.WriteLine(db.Delete("query"));

            #endregion

            #endregion

            #region Behavioral patterns (Chain of Responsibility, Command, Iterator, Mediator, Memento, Observer, State, Strategy, Template method, Visitor)

                #region Chain of Responsibility

                    Separation("---------------CHAIN OF RESPONCIBILITY----------------------------");

                    var handler = new CachedOrderHandler().SetNextHandler(new HttpOrderHandler()).SetNextHandler(new DbOrderHandler());

                    Console.WriteLine($"Value is - {handler.Find() }");

                #endregion

                #region Command

                    Separation("---------------COMMAND----------------------------");

                    ICommand command = new SaveCommand("query");
                    ICommand printCommand = new PrintCommand("printQuery");

                    Console.WriteLine(command.Execute());
                    Console.WriteLine(printCommand.Execute());

                #endregion

                #region Iterator

                    Separation("---------------ITERATOR----------------------------");

                    var book = new AddressBook<Record>();
                    book.Add(new Record("Mikhail", "Lenina 15"));
                    book.Add(new Record("Andrey", "Beni 23"));

                    foreach (var record in book)
                    {
                        Console.WriteLine($"Name - { record.Name }; Address - { record.Address }");
                    }

                    book.ReverseDirection();
                    Console.WriteLine("Reversed");
                    foreach (var record in book)
                    {
                        Console.WriteLine($"Name - { record.Name }; Address - { record.Address }");
                    }

                #endregion

                #region Mediator

                    Separation("---------------MEDIATOR----------------------------");

                    var button = new Button();
                    var label = new Label();
                    var mediator = new ComponentMediator(button, label);
                    var response = button.Click();
                    Console.WriteLine(response);
                    Console.WriteLine($"Label property was changed to {label.Enabled}");

                #endregion

                #region Memento

                    Separation("---------------MEMENTO----------------------------");

                    var textEditor = new TextEditor();
                    textEditor.SetText("First", "Bold");
                    var memento = new MementoHistoty(textEditor);
                    memento.Backup();
                    textEditor.SetText("Second", "Italic");
                    memento.Undo();
                    Console.WriteLine(textEditor.ShowText());

                #endregion

                #region Observer

                    Separation("---------------OBSERVER----------------------------");

                    var shop = new Shop();
                    shop.Name = "Title";
                    var observer = new Consumer();
                    var observable = new ShopObservable(shop);
                    var obs2 = new Consumer();
                    observable.Subscribe(observer);
                    var e = observable.Subscribe(obs2);
                    observable.Notify();
                    e.Dispose();
                    observable.Notify();

                #endregion

                #region State

                    Separation("---------------STATE----------------------------");

                    var draft = new DraftState();
                    var release = new ReleaseState();
                    var doc = new Document();
                    doc.Name = "Title";
                    doc.State = "draft";
                    var context = new DocumentContext(doc.State.Equals("draft") ? draft : release);
                    Console.WriteLine(context.Publish(doc));
                    Console.WriteLine(context.Publish(doc));

                #endregion

                #region Strategy

                    Separation("---------------STRATEGY----------------------------");

                    var carRoute = new CarNavigation();
                    var publicRoute = new PublicNavigation();
                    var strategy = new NavigationStrategy(carRoute);
                    Console.WriteLine(strategy.BuildRoute());
                    strategy.SetStrategy(publicRoute);
                    Console.WriteLine(strategy.BuildRoute());

                #endregion

                #region Template method

                    Separation("---------------TEMPLATE METHOD----------------------------");

                    IDocument document = new PDFReader();
                    Console.WriteLine(document.Do());
                    document = new DocReader();
                    Console.WriteLine(document.Do());

                #endregion

                #region Visitor

                    Separation("---------------VISITOR----------------------------");

                    var cityLoc = new CityLocation();
                    var restorauntLoc = new RestorauntLocation();
                    var visitor = new LocationVisitor();
                    Console.WriteLine(cityLoc.Export(visitor));
                    Console.WriteLine(restorauntLoc.Export(visitor));

                #endregion

            #endregion

        }

        #region Private methods

        private static void Separation(string designPatternName)
        {
            Console.WriteLine();
            Console.WriteLine(designPatternName);
            Console.WriteLine();
        }

        #endregion
    }
}
