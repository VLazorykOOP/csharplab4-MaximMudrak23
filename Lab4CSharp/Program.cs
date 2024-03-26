// Task1
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

    // Індексатор
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

    // Перевантаження оператора ++
    public static Triangle operator ++(Triangle triangle)
    {
        triangle.x1++;
        triangle.x2++;
        triangle.x3++;
        return triangle;
    }

    // Перевантаження оператора --
    public static Triangle operator --(Triangle triangle)
    {
        triangle.x1--;
        triangle.x2--;
        triangle.x3--;
        return triangle;
    }

    // Перевантаження оператора *
    public static Triangle operator *(Triangle triangle, int scalar)
    {
        triangle.x1 *= scalar;
        triangle.x2 *= scalar;
        triangle.x3 *= scalar;
        return triangle;
    }
    
    // Явне перетворення Triangle в bool
    public static explicit operator bool(Triangle triangle)
    {
        return triangle.CheckTriangleExistence();
    }

    // Перевірка існування трикутника
    private bool CheckTriangleExistence()
    {
        double AB = CalculateDistance(x1, y1, x2, y2);
        double BC = CalculateDistance(x2, y2, x3, y3);
        double CA = CalculateDistance(x3, y3, x1, y1);

        return AB + BC > CA && AB + CA > BC && BC + CA > AB;
    }

    // Перетворення Triangle в string
    public static implicit operator string(Triangle triangle)
    {
        return $"Triangle: ({triangle.x1},{triangle.y1}), ({triangle.x2},{triangle.y2}), ({triangle.x3},{triangle.y3}), Color: {triangle.color}";
    }

    // Перетворення string в Triangle
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
// Task1
// Task2
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

    public static VectorUInt operator -(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 - val2;
        }
        return result;
    }

    public static VectorUInt operator -(VectorUInt vec, uint scalar)
    {
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] - scalar;
        }
        return result;
    }

    public static VectorUInt operator *(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 * val2;
        }
        return result;
    }

    public static VectorUInt operator *(VectorUInt vec, uint scalar)
    {
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] * scalar;
        }
        return result;
    }

    public static VectorUInt operator /(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 1; // Уникнення ділення на 0
            result.IntArray[i] = val1 / val2;
        }
        return result;
    }

    public static VectorUInt operator /(VectorUInt vec, uint scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Division by zero");
        }
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] / scalar;
        }
        return result;
    }

    public static VectorUInt operator %(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 1; // Уникнення ділення на 0
            result.IntArray[i] = val1 % val2;
        }
        return result;
    }

    public static VectorUInt operator %(VectorUInt vec, uint scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Division by zero");
        }
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] % scalar;
        }
        return result;
    }

    public static VectorUInt operator |(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 | val2;
        }
        return result;
    }

    public static VectorUInt operator &(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 & val2;
        }
        return result;
    }

    public static VectorUInt operator ^(VectorUInt vec1, VectorUInt vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            uint val1 = (i < vec1.size) ? vec1.IntArray[i] : 0;
            uint val2 = (i < vec2.size) ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 ^ val2;
        }
        return result;
    }

    public static VectorUInt operator ~(VectorUInt vec)
    {
        VectorUInt result = new VectorUInt(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = ~vec.IntArray[i];
        }
        return result;
    }
}
// Task2
// Task3
class MatrixUint
{
    protected uint[,] IntArray;
    protected int n, m;
    protected int codeError;
    static int num_m;

    // Конструктори
    public MatrixUint()
    {
        n = m = 1;
        IntArray = new uint[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUint(int n, int m)
    {
        this.n = n;
        this.m = m;
        IntArray = new uint[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUint(int n, int m, uint initialValue)
    {
        this.n = n;
        this.m = m;
        IntArray = new uint[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = initialValue;
            }
        }
        codeError = 0;
        num_m++;
    }

    // Деструктор
    ~MatrixUint()
    {
        Console.WriteLine("Matrix deleted.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                IntArray[i, j] = uint.Parse(Console.ReadLine());
            }
        }
    }

    public void DisplayElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(IntArray[i, j] + "\t");
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
    public int N { get { return n; } }
    public int M { get { return m; } }
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
            if (i >= 0 && i < n && j >= 0 && j < m)
                return IntArray[i, j];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                IntArray[i, j] = value;
            else
                codeError = -1;
        }
    }

    public uint this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;
            if (i >= 0 && i < n && j >= 0 && j < m)
                return IntArray[i, j];
            else
            {
                codeError = -1;
                return 0;
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

    public static bool operator true(MatrixUint matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            foreach (uint element in matrix.IntArray)
            {
                if (element != 0)
                    return true;
            }
        }
        return false;
    }

    public static bool operator false(MatrixUint matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixUint matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }
}
// Task3

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

        // Task1
        // Task2

        //// Створення об'єкта класу VectorUInt без параметрів
        //VectorUInt vector1 = new VectorUInt();

        //// Введення елементів вектора з клавіатури
        //vector1.InputVector();

        //// Виведення елементів вектора на екран
        //vector1.DisplayVector();

        //// Перевірка на істинність (чи всі елементи вектора не рівні 0)
        //if (vector1)
        //    Console.WriteLine("Не всі елементи рівні 0");
        //else
        //    Console.WriteLine("Всі елементи рівні 0");

        //// Створення об'єкта класу VectorUInt з одним параметром - розміром вектора
        //VectorUInt vector2 = new VectorUInt(3);

        //// Виведення елементів вектора на екран
        //vector2.DisplayVector();

        //// Присвоєння всім елементам масиву певного значення
        //vector2.SetValues(5);

        //// Виведення елементів вектора на екран
        //vector2.DisplayVector();

        //// Створення об'єкта класу VectorUInt із двома параметрами - розміром вектора та значенням ініціалізації
        //VectorUInt vector3 = new VectorUInt(2, 10);

        //// Виведення елементів вектора на екран
        //vector3.DisplayVector();

        //// Перевірка на істинність (чи всі елементи вектора не рівні 0)
        //if (vector3)
        //    Console.WriteLine("Vector contains non-zero elements");
        //else
        //    Console.WriteLine("Vector contains only zeros");

        //// Перегляд розмірності вектора
        //Console.WriteLine("Vector size: " + vector3.Size);

        //// Перегляд коду помилки
        //Console.WriteLine("Error code: " + vector3.ErrorCode);

        //// Додавання двох векторів
        //VectorUInt sum = vector1 + vector2;

        //// Виведення елементів вектора на екран
        //sum.DisplayVector();

        //// Додавання скаляра до вектора
        //VectorUInt sumScalar = vector1 + 5;

        //// Виведення елементів вектора на екран
        //sumScalar.DisplayVector();

        //// Збільшення вектора на одиницю (++vec)
        //VectorUInt incrementedVector = ++vector1;

        //// Виведення елементів вектора на екран
        //incrementedVector.DisplayVector();

        //// Зменшення вектора на одиницю (--vec)
        //VectorUInt decrementedVector = --vector2;

        //// Виведення елементів вектора на екран
        //decrementedVector.DisplayVector();

        //// Перевірка на істинність (чи всі елементи вектора не рівні 0)
        //if (decrementedVector)
        //    Console.WriteLine("Vector contains non-zero elements");
        //else
        //    Console.WriteLine("Vector contains only zeros");

        //// Використання бітових операцій
        //VectorUInt bitwiseOr = vector1 | vector2;
        //VectorUInt bitwiseAnd = vector1 & vector2;
        //VectorUInt bitwiseXor = vector1 ^ vector2;
        //VectorUInt bitwiseNot = ~vector1;

        //// Виведення результатів бітових операцій
        //bitwiseOr.DisplayVector();
        //bitwiseAnd.DisplayVector();
        //bitwiseXor.DisplayVector();
        //bitwiseNot.DisplayVector();

        // Task2
        // Task3

        // Створення матриці за допомогою різних конструкторів
        MatrixUint matrix1 = new MatrixUint(); // конструктор без параметрів
        MatrixUint matrix2 = new MatrixUint(2, 3); // конструктор із двома параметрами
        MatrixUint matrix3 = new MatrixUint(2, 2, 5); // конструктор із трьома параметрами

        // Вивід розмірності матриці
        Console.WriteLine($"Matrix1 size: {matrix1.N}x{matrix1.M}");
        Console.WriteLine($"Matrix2 size: {matrix2.N}x{matrix2.M}");
        Console.WriteLine($"Matrix3 size: {matrix3.N}x{matrix3.M}");

        // Введення елементів матриці з клавіатури
        Console.WriteLine("Enter elements for matrix1:");
        matrix1.InputElements();

        // Вивід елементів матриці на екран
        Console.WriteLine("Matrix1 elements:");
        matrix1.DisplayElements();

        // Вивід елементів матриці на екран
        Console.WriteLine("Matrix2 elements:");
        matrix2.DisplayElements();

        // Вивід елементів матриці на екран
        Console.WriteLine("Matrix3 elements:");
        matrix3.DisplayElements();

        // Присвоєння всім елементам матриці певного значення
        uint value = 10;
        Console.WriteLine($"Assigning value {value} to all elements of matrix2:");
        matrix2.AssignValue(value);

        // Вивід елементів матриці на екран
        Console.WriteLine("Matrix2 elements after assigning value:");
        matrix2.DisplayElements();

        // Підрахунок кількості матриць
        Console.WriteLine($"Number of matrices: {MatrixUint.CountMatrices()}");

        // Використання індексаторів
        Console.WriteLine($"Element at index [1, 1] of matrix1: {matrix1[1, 1]}");
        Console.WriteLine($"Element at index [3] of matrix2: {matrix2[3]}");

        // Перевантаження операторів
        MatrixUint incrementedMatrix = ++matrix1;
        Console.WriteLine("Matrix1 after increment:");
        incrementedMatrix.DisplayElements();

        MatrixUint decrementedMatrix = --matrix2;
        Console.WriteLine("Matrix2 after decrement:");
        decrementedMatrix.DisplayElements();

        if (matrix3)
            Console.WriteLine("Matrix3 is not empty.");
        else
            Console.WriteLine("Matrix3 is empty.");

        Console.WriteLine($"Logical negation of matrix3: {!matrix3}");

        // Task3
    }
}