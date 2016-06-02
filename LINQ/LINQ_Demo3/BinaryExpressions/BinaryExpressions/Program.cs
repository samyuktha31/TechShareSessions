using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BinaryExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expression trees
            //(5 + 9) * (3 - 2)

            // 5 + 9
            BinaryExpression basicBinaryExpression1 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(5), Expression.Constant(9));

            //(3 - 2)
            BinaryExpression basicBinaryExpression2 = Expression.MakeBinary(ExpressionType.Subtract, Expression.Constant(3), Expression.Constant(2));

            //(5 + 9) * (3 - 2)
            BinaryExpression basicBinaryExpression3 = Expression.MakeBinary(ExpressionType.Multiply, basicBinaryExpression1, basicBinaryExpression2);

            int result = Expression.Lambda<Func<int>>(basicBinaryExpression3).Compile()();

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
