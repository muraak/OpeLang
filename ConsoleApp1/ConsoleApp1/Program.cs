using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SampleLanguage.Interpreter;
using SampleLanguage.Expression;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleInterpreter.Execute("1+1\n");
            Console.Read();
        }
    }

    public class SampleInterpreter
    {
        public static void Execute(string script)
        {
            var lexer = new Lexer(script);
            var parser = new Parser();
            var expression = (IExpression)parser.yyparse(lexer);

            System.Console.WriteLine(expression.Evaluate());
        }
    }
}

namespace SampleLanguage.Expression
{
    public interface IExpression
    {
        double Evaluate();
    }

    public class NumberExpression : IExpression
    {
        private double _num;

        public NumberExpression(double num)
        {
            _num = num;
        }

        public double Evaluate()
        {
            return _num;
        }
    }

    public class OpAddExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public OpAddExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public double Evaluate()
        {
            return _left.Evaluate() + _right.Evaluate();
        }
    }

    public class OpSubExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public OpSubExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public double Evaluate()
        {
            return _left.Evaluate() - _right.Evaluate();
        }
    }

    public class OpMulExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public OpMulExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public double Evaluate()
        {
            return _left.Evaluate() * _right.Evaluate();
        }
    }

    public class OpDivExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public OpDivExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public double Evaluate()
        {
            return _left.Evaluate() / _right.Evaluate();
        }
    }
}
