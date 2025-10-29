namespace kvandijk.Common.Diagnostics;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class SkipRequestTimingAttribute : Attribute
{
}