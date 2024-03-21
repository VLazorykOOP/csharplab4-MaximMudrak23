enum Color
{
    Orange,
    Black,
    Pink,
    Blue,
    Red,
    Yellow
}
class Triangle
{
    protected int x1, y1, x2, y2, x3, y3;
    protected Color color;

    // Оператор индексации
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x1;
                case 1: return x2;
                case 2: return x3;
                case 3: return color;
                default: throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x1 = (int)value; break;
                case 1: x2 = (int)value; break;
                case 2: x3 = (int)value; break;
                case 3: color = (Color)value; break;
                default: throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
        }
    }

    // Перегрузка оператора ++
    public static Triangle operator ++(Triangle triangle)
    {
        triangle.x1++;
        triangle.x2++;
        triangle.x3++;
        return triangle;
    }

    // Перегрузка оператора --
    public static Triangle operator --(Triangle triangle)
    {
        triangle.x1--;
        triangle.x2--;
        triangle.x3--;
        return triangle;
    }

    // Явное преобразование Triangle в bool
    public static explicit operator bool(Triangle triangle)
    {
        return triangle.CheckTriangleExistence();
    }

    // Перегрузка оператора *
    public static Triangle operator *(Triangle triangle, int scalar)
    {
        triangle.x1 *= scalar;
        triangle.x2 *= scalar;
        triangle.x3 *= scalar;
        return triangle;
    }

    // Проверка существования треугольника
    private bool CheckTriangleExistence()
    {
        double AB = CalculateDistance(x1, y1, x2, y2);
        double BC = CalculateDistance(x2, y2, x3, y3);
        double CA = CalculateDistance(x3, y3, x1, y1);

        return AB + BC > CA && AB + CA > BC && BC + CA > AB;
    }

    // Преобразование Triangle в string
    public static implicit operator string(Triangle triangle)
    {
        return $"Triangle: ({triangle.x1},{triangle.y1}), ({triangle.x2},{triangle.y2}), ({triangle.x3},{triangle.y3}), Color: {triangle.color}";
    }

    // Преобразование string в Triangle
    public static implicit operator Triangle(string triangleString)
    {
        string[] parts = triangleString.Split(new char[] { '(', ',', ')', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Triangle triangle = new Triangle();
        triangle.x1 = int.Parse(parts[1]);
        triangle.y1 = int.Parse(parts[2]);
        triangle.x2 = int.Parse(parts[4]);
        triangle.y2 = int.Parse(parts[5]);
        triangle.x3 = int.Parse(parts[7]);
        triangle.y3 = int.Parse(parts[8]);
        triangle.color = (Color)Enum.Parse(typeof(Color), parts[10].Trim(), true);
        return triangle;
    }

    public void CreateTr()
    {
        Console.Write("x1: ");
        x1 = int.Parse(Console.ReadLine());

        Console.Write("y1: ");
        y1 = int.Parse(Console.ReadLine());

        Console.Write("x2: ");
        x2 = int.Parse(Console.ReadLine());

        Console.Write("y2: ");
        y2 = int.Parse(Console.ReadLine());

        Console.Write("x3: ");
        x3 = int.Parse(Console.ReadLine());

        Console.Write("y3: ");
        y3 = int.Parse(Console.ReadLine());

        Console.Write("Color (Orange, Black, Pink, Blue, Red, Yellow): ");
        string colorInput = Console.ReadLine();
        color = (Color)Enum.Parse(typeof(Color), colorInput, true);
    }
    public void TakeColor()
    {
        Console.WriteLine(color.ToString());
    }
    public void TakeSetLong()
    {
        Console.WriteLine("Enter the new lengths for the sides:");
        Console.Write("AB: ");
        double newAB = double.Parse(Console.ReadLine());
        Console.Write("BC: ");
        double newBC = double.Parse(Console.ReadLine());
        Console.Write("CA: ");
        double newCA = double.Parse(Console.ReadLine());

        SetSideLength(newAB, newBC, newCA);
        Long();
    }
    public void SetSideLength(double newAB, double newBC, double newCA)
    {
        // x2 та y2, AB
        double angleAB = Math.Atan2(y2 - y1, x2 - x1);
        x2 = x1 + (int)(newAB * Math.Cos(angleAB));
        y2 = y1 + (int)(newAB * Math.Sin(angleAB));

        // x3 та y3, BC
        double angleBC = Math.Atan2(y3 - y2, x3 - x2);
        x3 = x2 + (int)(newBC * Math.Cos(angleBC));
        y3 = y2 + (int)(newBC * Math.Sin(angleBC));

        // x1 та y1, CA
        double angleCA = Math.Atan2(y1 - y3, x1 - x3);
        x1 = x3 + (int)(newCA * Math.Cos(angleCA));
        y1 = y3 + (int)(newCA * Math.Sin(angleCA));

        Console.WriteLine("Side lengths have been updated successfully!");
    }
    public void Long()
    {
        double AB = CalculateDistance(x1, y1, x2, y2);
        double BC = CalculateDistance(x2, y2, x3, y3);
        double CA = CalculateDistance(x3, y3, x1, y1);

        Console.WriteLine($"Long side AB: {AB}");
        Console.WriteLine($"Long side BC: {BC}");
        Console.WriteLine($"Long side CA: {CA}");
    }
    public void Perimeter()
    {
        double AB = CalculateDistance(x1, y1, x2, y2);
        double BC = CalculateDistance(x2, y2, x3, y3);
        double CA = CalculateDistance(x3, y3, x1, y1);

        double perimeter = AB + BC + CA;
        Console.WriteLine($"Perimeter: {perimeter}");
    }
    public void Square()
    {
        double AB = CalculateDistance(x1, y1, x2, y2);
        double BC = CalculateDistance(x2, y2, x3, y3);
        double CA = CalculateDistance(x3, y3, x1, y1);

        double p = (AB + BC + CA) / 2; // напівпериметр
        double square = Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA)); // формула Герона для площі трикутника

        Console.WriteLine($"Square: {square}");
    }
    static double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}

// That was task1, now task2

class VectorUInt
{
    protected uint[] IntArray; // масив
    protected uint size; // розмір вектора
    protected int codeError; // код помилки
    protected static uint num_vec; // кількість векторів

    // Конструктор без параметрів
    public VectorUInt()
    {
        size = 1;
        IntArray = new uint[size];
        codeError = 0;
        num_vec++;
    }

    // Конструктор з одним параметром - розмір вектора
    public VectorUInt(uint vectorSize)
    {
        size = vectorSize;
        IntArray = new uint[size];
        codeError = 0;
        num_vec++;
    }

    // Конструктор із двома параметрами - розмір вектора та значення ініціалізації
    public VectorUInt(uint vectorSize, uint initValue)
    {
        size = vectorSize;
        IntArray = new uint[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~VectorUInt()
    {
        Console.WriteLine("Vector destroyed");
    }

    // Метод для введення елементів вектора з клавіатури
    public void InputVector()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter element {0}: ", i);
            IntArray[i] = Convert.ToUInt32(Console.ReadLine());
        }
    }

    // Метод для виведення елементів вектора на екран
    public void DisplayVector()
    {
        Console.WriteLine("Vector elements:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Element {0}: {1}", i, IntArray[i]);
        }
    }

    // Метод для присвоєння всім елементам масиву певного значення
    public void SetValues(uint value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    // Статичний метод, що підраховує кількість векторів даного типу
    public static uint CountVectors()
    {
        return num_vec;
    }

    // Властивість для отримання розмірності вектора
    public uint Size
    {
        get { return size; }
    }

    // Властивість для доступу до поля codeError
    public int ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public uint this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                return IntArray[index];
            }
        }
        set
        {
            if (index >= 0 && index < size)
            {
                IntArray[index] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Перевантаження унарних операторів ++ і --
    public static VectorUInt operator ++(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]++;
        }
        return vec;
    }

    public static VectorUInt operator --(VectorUInt vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]--;
        }
        return vec;
    }

    // Перевантаження сталих true і false
    public static bool operator true(VectorUInt vec)
    {
        foreach (var item in vec.IntArray)
        {
            if (item != 0)
                return true;
        }
        return false;
    }

    public static bool operator false(VectorUInt vec)
    {
        foreach (var item in vec.IntArray)
        {
            if (item != 0)
                return false;
        }
        return true;
    }

    // Перевантаження бінарних операторів
    // Приклади операторів +, -, *, /, %
    public static VectorUInt operator +(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 + val2;
        }
        return result;
    }

    public static VectorUInt operator +(VectorUInt vec, uint scalar)
    {
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] + scalar;
        }
        return result;
    }

    // Додаткові перевантаження операторів та інші методи можна додати за аналогією
}

// Class from task3

class MatrixUint
{
    private uint[,] IntArray;
    private int n, m;
    private int codeError;
    private static int num_m;

    // Конструктори
    public MatrixUint() : this(1, 1) { }

    public MatrixUint(int rows, int cols) : this(rows, cols, 0) { }

    public MatrixUint(int rows, int cols, uint initialValue)
    {
        n = rows;
        m = cols;
        codeError = 0;
        IntArray = new uint[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = initialValue;
            }
        }
        num_m++;
    }

    // Деструктор
    ~MatrixUint()
    {
        num_m--;
    }

    // Методи
    public void InputElements()
    {
        Console.WriteLine("Enter elements of the matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = Convert.ToUInt32(Console.ReadLine());
            }
        }
    }

    public void PrintElements()
    {
        Console.WriteLine("Matrix elements:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(IntArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(uint value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public static int CountMatrices()
    {
        return num_m;
    }

    // Властивості
    public int Rows => n;

    public int Cols => m;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public uint this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return IntArray[0, 0];
            }
            return IntArray[i, j];
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public uint this[int k]
    {
        get
        {
            if (k < 0 || k >= n * m)
            {
                codeError = -1;
                return IntArray[0, 0];
            }
            return IntArray[k / m, k % m];
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                IntArray[k / m, k % m] = value;
            }
        }
    }

    // Перевантаження операторів
    public static MatrixUint operator ++(MatrixUint matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixUint operator --(MatrixUint matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator !(MatrixUint matrix)
    {
        return (matrix.n != 0 && matrix.m != 0);
    }

    public static bool operator ==(MatrixUint matrix1, MatrixUint matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m) return false;
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.IntArray[i, j] != matrix2.IntArray[i, j]) return false;
            }
        }
        return true;
    }

    public static bool operator !=(MatrixUint matrix1, MatrixUint matrix2)
    {
        return !(matrix1 == matrix2);
    }
}

// Down there we have our main function

class Program
{
    static void Main(string[] args)
    {
        // Task1
        //// Створюємо обьєкт трикутника
        //Triangle triangle1 = new Triangle();

        //// Створюємо трикутник за допомогою метода CreateTr
        //triangle1.CreateTr();

        //// Виводимо довжини сторін трикутника
        //Console.WriteLine("Довжини сторін");
        //triangle1.Long();

        //// Виводимо периметр трикутника
        //Console.WriteLine("Периметр");
        //triangle1.Perimeter();

        //// Виводимо площу трикутника
        //Console.WriteLine("Площа");
        //triangle1.Square();

        //// Добавляемо одиницю до каждої сторони трикутника за допомогою оператора ++
        //triangle1++;

        //// Виводимо довжини сторін трикутника після використання оператора ++
        //Console.WriteLine("Довжини сторін після ++");
        //triangle1.Long();

        //// Зменшуємо кожну сторону трикутника на одиницю за допомогою оператора --
        //triangle1--;

        //// Виводимо довжини сторін трикутника після використання оператора --
        //Console.WriteLine("Довжини сторін після --");
        //triangle1.Long();

        //// Перевіряємо існування трикутника
        //bool triangleExists = (bool)triangle1;
        //Console.WriteLine($"Чи існує трикутник: {triangleExists}");

        //// Множимо кожну сторону трикутника на 2 за допомогою оператора *
        //triangle1 *= 2;

        //// Виводимо довжини сторін трикутника після використання оператора *
        //Console.WriteLine("Довжини сторін після *");
        //triangle1.Long();

        //// Виводимо колір трикутника
        //Console.WriteLine("Колір треугольника");
        //triangle1.TakeColor();

        //// Преобразуем обьект трикутника в строку
        //string triangleString = triangle1;

        //// Виводимо строковое уявлення трикутника
        //Console.WriteLine($"Строковое уявлення трикутника: {triangleString}");

        // Task2

        // Створення екземпляра класу VectorUInt за допомогою конструктора без параметрів
        //VectorUInt vector = new VectorUInt();
        //VectorUInt vector = new VectorUInt(5, 2);

        //// Виклик методу для введення елементів вектора з клавіатури
        //vector.InputVector();

        //// Виклик методу для виведення елементів вектора на екран
        //vector.DisplayVector();

        //// Виклик методу для присвоєння всім елементам масиву певного значення
        //vector.SetValues(10);

        //// Виклик методу для виведення оновлених елементів вектора на екран
        //vector.DisplayVector();

        //// Виклик статичного методу для підрахунку кількості векторів
        //uint count = VectorUInt.CountVectors();
        //Console.WriteLine("Number of VectorUInt instances: " + count);

        //// Використання індексатора для звертання до елементів масиву
        //uint element = vector[0];
        //Console.WriteLine("Element at index 0: " + element);

        //// Зміна значення поля коду помилки через властивість
        //vector.ErrorCode = -1;
        //Console.WriteLine("Error code: " + vector.ErrorCode);

        //// Приклади використання перевантажених операторів
        //VectorUInt vector2 = new VectorUInt(3, 5);
        //VectorUInt sum = vector + vector2;
        //sum.DisplayVector();

        //VectorUInt scalarSum = vector + 3;
        //scalarSum.DisplayVector();

        //// Використання унарного оператору ++
        //vector++;
        //vector.DisplayVector();

        //// Очікуємо введення користувачем для завершення програми
        //Console.ReadLine();

        // Task3
        //MatrixUint A = new MatrixUint(2, 2, 1);
        //A.PrintElements();
        //A[0, 0] = 5;
        //Console.WriteLine("Element at (0, 0): " + A[0, 0]);
        //++A;
        //A.PrintElements();
        //Console.WriteLine("Number of matrices: " + MatrixUint.CountMatrices());
    }
}