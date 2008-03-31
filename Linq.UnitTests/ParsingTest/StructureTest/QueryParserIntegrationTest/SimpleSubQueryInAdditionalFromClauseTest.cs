using System.Linq;
using NUnit.Framework;
using Rubicon.Data.Linq.Clauses;
using Rubicon.Data.Linq.UnitTests.TestQueryGenerators;

namespace Rubicon.Data.Linq.UnitTests.ParsingTest.StructureTest.QueryParserIntegrationTest
{
  [TestFixture]
  // [Ignore ("TODO: Implement MainFromClauses without constant IQueryable")]
  public class SimpleSubQueryInAdditionalFromClauseTest : QueryTestBase<Student>
  {
    protected override IQueryable<Student> CreateQuery ()
    {
      return SubQueryTestQueryGenerator.CreateSimpleSubQueryInAdditionalFromClause (QuerySource);
    }

    [Test]
    public override void CheckBodyClauses ()
    {
      Assert.AreEqual (1, ParsedQuery.BodyClauses.Count);

      SubQueryFromClause fromClause1 = ParsedQuery.BodyClauses[0] as SubQueryFromClause;
      Assert.IsNotNull (fromClause1);
      Assert.AreSame (SourceExpressionNavigator.Arguments[1].Operand.Body.Expression, fromClause1.SubQueryModel.GetExpressionTree ());
      Assert.AreSame (SourceExpressionNavigator.Arguments[2].Operand.Expression, fromClause1.ProjectionExpression);

      CheckSubQuery (fromClause1.SubQueryModel);
    }

    private void CheckSubQuery (QueryModel subQuery)
    {
      ExpressionTreeNavigator subExpressionNavigator = SourceExpressionNavigator.Arguments[1].Operand.Body;

      Assert.IsNotNull (subQuery.MainFromClause);
      Assert.AreSame (subExpressionNavigator.Arguments[0].Expression, subQuery.MainFromClause.QuerySource);
      Assert.AreSame (subExpressionNavigator.Arguments[1].Operand.Parameters[0].Expression, subQuery.MainFromClause.Identifier);

      Assert.AreEqual (0, subQuery.BodyClauses.Count);

      SelectClause selectClause = subQuery.SelectOrGroupClause as SelectClause;
      Assert.IsNotNull (selectClause);
      Assert.AreSame (subExpressionNavigator.Arguments[1].Operand.Expression, selectClause.ProjectionExpression);
    }

    [Test]
    public override void CheckSelectOrGroupClause ()
    {
      SelectClause selectClause = ParsedQuery.SelectOrGroupClause as SelectClause;
      Assert.IsNotNull (selectClause);
      Assert.AreSame (SourceExpressionNavigator.Arguments[2].Operand.Expression, selectClause.ProjectionExpression);
    }

    [Test]
    public override void OutputResult ()
    {
      base.OutputResult ();
    }
    
  }
}