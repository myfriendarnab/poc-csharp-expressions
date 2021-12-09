using System;
using System.Linq.Expressions;

namespace ExpressionTree_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<string, string>> toUpperExp = s => s.ToUpper();

            Func<string, string> toup = toUpperExp.Compile();

            var upprResp = toup("sdssd");
            Console.WriteLine(upprResp);

            //Exp for s=>s.ToUpper() lambda
            var prm = Expression.Parameter(typeof(string), "str");
            var toLower = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
            var body = Expression.Call(prm, toLower);
            var lambda = Expression.Lambda(body, prm);

            var del = lambda.Compile();
            var lowrResp= del.DynamicInvoke(upprResp);
            Console.WriteLine(lowrResp);

            Console.Read();
        }
    }
}
