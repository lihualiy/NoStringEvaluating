﻿using System.Collections.Generic;
using NoStringEvaluatingTests.Model;

namespace NoStringEvaluatingTests.Formulas;

public static partial class FormulasContainer
{
    public static IEnumerable<FormulaModel[]> GetBooleanFormulas()
    {
        var myTrue = true;
        var myFalse = false;

        yield return CreateTestModel("true == false", false);
        yield return CreateTestModel("true == true", true);
        yield return CreateTestModel("true || false", true);
        yield return CreateTestModel("(true && false) || false", false);
        yield return CreateTestModel("(true && false) || false || 1 != 0", true);
        yield return CreateTestModel("(true || false) || false", true);
        yield return CreateTestModel("1 + 2 > 4", false);
        yield return CreateTestModel("1 + 2 > 2", true);
        yield return CreateTestModel("if(myTrue; 0; 1)", false, ("myTrue", myTrue));
        yield return CreateTestModel("Not([my false])", true, ("my false", myFalse));

        // IsText
        yield return CreateTestModel("IsText(26)", false);
        yield return CreateTestModel("IsText('26')", true);
        yield return CreateTestModel("IsText('Hello!')", true);

        // IsNumber
        yield return CreateTestModel("IsNumber(26)", true);
        yield return CreateTestModel("IsNumber('26')", false);
        yield return CreateTestModel("IsNumber('Hello!')", false);

        // Null Boolean
        yield return CreateTestModel("NullIf(3;3) == null", true);
        yield return CreateTestModel("NullIf(4;3) == 4", true);
        yield return CreateTestModel("IfNull(thisisanullvar;'somethingelse') == 'somethingelse'", true);
        yield return CreateTestModel("IfNull('thisisnotnull';'somethingelse') == 'thisisnotnull'", true);
        yield return CreateTestModel("nuLl == 3", false);
        yield return CreateTestModel("nuLl == abc", true); // both null

        // DateTime boolean Comparison
        yield return CreateTestModel("ToDateTime('04/18/2021') > ToDateTime('04/17/2021')", true);
        yield return CreateTestModel("ToDateTime('04/18/2021') < ToDateTime('04/17/2021')", false);
        yield return CreateTestModel("ToDateTime('04/17/2021')+1 > ToDateTime('04/17/2021')", true);
        yield return CreateTestModel("ToDateTime('04/17/2021')-1 < ToDateTime('04/17/2021')", true);
        yield return CreateTestModel("ToDateTime('04/17/2021') == ToDateTime('04/17/2021')", true);
    }
}
