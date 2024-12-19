using System;

class Rectangle
{
    // Поля для координат
    protected double B1, A1, B2, A2;

    // Віртуальний метод для встановлення значень
    public virtual void SetCoefficients(double b1, double a1, double b2, double a2)
    {
        B1 = b1;
        A1 = a1;
        B2 = b2;
        A2 = a2;
    }

    // Віртуальний метод для виведення значень
    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Rectangle: B1={B1}, A1={A1}, B2={B2}, A2={A2}");
    }

    // Віртуальний метод для перевірки, чи належить точка
    public virtual bool ContainsPoint(double x, double y)
    {
        return B1 <= x && x <= A1 && B2 <= y && y <= A2;
    }
}

class Parallelepiped : Rectangle
{
    // Додаткові координати для Z-виміру
    private double C1, C2;

    // Перевизначення методу для встановлення значень
    public override void SetCoefficients(double b1, double a1, double b2, double a2)
    {
        base.SetCoefficients(b1, a1, b2, a2);
        Console.WriteLine("Use SetCoefficients with Z-dimensions for Parallelepiped.");
    }

    // Перевантажений метод для встановлення значень у 3D
    public void SetCoefficients(double b1, double a1, double b2, double a2, double c1, double c2)
    {
        base.SetCoefficients(b1, a1, b2, a2);
        C1 = c1;
        C2 = c2;
    }

    // Перевизначення методу для виведення значень
    public override void DisplayCoefficients()
    {
        base.DisplayCoefficients();
        Console.WriteLine($"Parallelepiped: C1={C1}, C2={C2}");
    }

    // Перевантажений метод для перевірки 3D точки
    public bool ContainsPoint(double x, double y, double z)
    {
        return base.ContainsPoint(x, y) && C1 <= z && z <= C2;
    }
}

class Program
{
    static void Main()
    {
        // Створення динамічного об'єкта Rectangle
        Rectangle rect = new Rectangle();
        rect.SetCoefficients(1, 5, 2, 6);
        rect.DisplayCoefficients();
        Console.WriteLine($"Point (3,4) in rectangle: {rect.ContainsPoint(3, 4)}");

        // Створення динамічного об'єкта Parallelepiped через базовий покажчик
        Rectangle parallelepiped = new Parallelepiped();
        ((Parallelepiped)parallelepiped).SetCoefficients(1, 5, 2, 6, 0, 10); // Виклик методу 3D
        parallelepiped.DisplayCoefficients();
        Console.WriteLine($"Point (3,4,5) in parallelepiped: {((Parallelepiped)parallelepiped).ContainsPoint(3, 4, 5)}");
    }
}

