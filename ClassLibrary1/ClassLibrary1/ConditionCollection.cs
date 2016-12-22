using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mcst.Model;
using ClassLibrary1.Conditions;

namespace ClassLibrary1
{
    public class ConditionCollection
    {

        Dictionary<string, ConditionObject<IProject>> projectConditions_;
        Dictionary<string, ConditionObject<ITask>> taskConditions_;
        Dictionary<string, ConditionObject<IStage>> stageConditions_;

        

        public ConditionCollection()
        {
            var properties = this.GetType().GetProperties()
                .Where(p => p.PropertyType.BaseType.IsConstructedGenericType && p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(ConditionObject<>))
                .ToArray();

            this.projectConditions_ = properties.Where(p => typeof(ConditionObject<IProject>).IsAssignableFrom(p.PropertyType))
                .Select(p => (ConditionObject<IProject>)p.GetValue(this))
                .ToDictionary(c => c.Name);

            this.taskConditions_ = properties.Where(p => typeof(ConditionObject<ITask>).IsAssignableFrom(p.PropertyType))
                .Select(p => (ConditionObject<ITask>)p.GetValue(this))
                .ToDictionary(c => c.Name);

            this.stageConditions_ = properties.Where(p => typeof(ConditionObject<IStage>).IsAssignableFrom(p.PropertyType))
                .Select(p => (ConditionObject<IStage>)p.GetValue(this))
                .ToDictionary(c => c.Name);
        }

        public ConditionObject<IProject> GetProjectCondition(string name)
        {
            return this.projectConditions_[name];
        }

        public ConditionObject<ITask> GetTaskCondition(string name)
        {
            return this.taskConditions_[name];
        }

        public ConditionObject<IStage> GetStageCondition(string name)
        {
            return this.stageConditions_[name];
        }

        public LinePimp LinePimp { get; } = new LinePimp();

        public LineStatusComplited LineStatusComplited { get; } = new LineStatusComplited();

        public LineStatusComplitedAhead LineStatusComplitedAhead { get; } = new LineStatusComplitedAhead();

        public ColumnStatusComplitedAhead ColumnStatusComplitedAhead { get; } = new ColumnStatusComplitedAhead();

        public LineStatusComplitedPartially LineStatusComplitedPartially { get; } = new LineStatusComplitedPartially();

        public LineStatusComplitedByGK LineStatusComplitedByGK { get; } = new LineStatusComplitedByGK();

        public LineStatusRemoveFromControl LineStatusRemoveFromControl { get; } = new LineStatusRemoveFromControl();

        public LineStatusCanceledByApplicant LineStatusCanceledByApplicant { get; } = new LineStatusCanceledByApplicant();

        public LineStatusStopped LineStatusStopped { get; } = new LineStatusStopped();

        public LineStatusUnknown LineStatusUnknown { get; } = new LineStatusUnknown();

        public ColumnStatusNeedDiscuss ColumnSatusNeedDiscuss { get; } = new ColumnStatusNeedDiscuss();

        public ColumnStatusNeedResult ColumnStatusNeedResult { get; } = new ColumnStatusNeedResult();

        public ColumnStatusControlEveryweek ColumnStatusControlEveryweek { get; } = new ColumnStatusControlEveryweek();

        public ColumnCriticalWayTrue ColumnCriticalWayTrue { get; } = new ColumnCriticalWayTrue();

        public ColumnShiftLegal ColumnShiftLegal { get; } = new ColumnShiftLegal();

        public ColumnShiftIllegal ColumnShiftIllegal { get; } = new ColumnShiftIllegal();

        public ColumnShiftRequested ColumnShiftRequested { get; } = new ColumnShiftRequested();

        public ColumnShiftGestation ColumnShiftGestation { get; } = new ColumnShiftGestation();

        public PartColumnShiftReason PartColumnShiftReason { get; } = new PartColumnShiftReason();

        public PartColumnShiftCulprit PartColumnShiftCulprit { get; } = new PartColumnShiftCulprit();

        public PartColumnRiskBad PartColumnRiskBad { get; } = new PartColumnRiskBad();

        public ColumnInformationNondisplacementDeadline ColumnInformationNondisplacementDeadline { get; } = new ColumnInformationNondisplacementDeadline();

        public ColumnInformationRequiredResult ColumnInformationRequiredResult { get; } = new ColumnInformationRequiredResult();

        public ColumnInformationRepeatedTask ColumnInformationRepeatedTask { get; } = new ColumnInformationRepeatedTask();

        public ColumnInformationTaskByGK ColumnInformationTaskByGK { get; } = new ColumnInformationTaskByGK();

        public ColumnInformationTaskByGD ColumnInformationTaskByGD { get; } = new ColumnInformationTaskByGD();

        public ColumnInformationRiskSquanderDeadline ColumnInformationRiskSquanderDeadline { get; } = new ColumnInformationRiskSquanderDeadline();

        public ColumnInformationNeedCorrectionDeadline ColumnInformationNeedCorrectionDeadline { get; } = new ColumnInformationNeedCorrectionDeadline();

        public ColumnDateDeadlineSoon ColumnDateDeadlineSoon { get; } = new ColumnDateDeadlineSoon();

        public ColumnDateDeadlineWeek ColumnDateDeadlineWeek { get; } = new ColumnDateDeadlineWeek();

        public ColumnDateDeadlineSquander ColumnDateDeadlineSquander { get; } = new ColumnDateDeadlineSquander();

        public ColumnDateUnknown ColumnDateUnknown { get; } = new ColumnDateUnknown();

        public ColumnLagReasonBlocked ColumnLagReasonBlocked { get; } = new ColumnLagReasonBlocked();

        public ColumnResourceUnknown ColumnResourceUnknown { get; } = new ColumnResourceUnknown();

        public LineFlagHided LineFlagHided { get; } = new LineFlagHided();

        public ColumnPriorityHigh ColumnPriorityHigh { get; } = new ColumnPriorityHigh();

        public ColumnPriorityTop ColumnPriorityTop { get; } = new ColumnPriorityTop();
    }
}
