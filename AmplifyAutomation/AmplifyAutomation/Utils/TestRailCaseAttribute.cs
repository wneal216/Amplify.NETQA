using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class TestRailCaseAttribute : Attribute
{
    public int CaseId { get; }

    public TestRailCaseAttribute(int caseId)
    {
        CaseId = caseId;
    }
}
