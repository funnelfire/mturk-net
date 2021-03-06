﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 
namespace MTurk.DTO {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd", IsNullable=false)]
    public partial class AnswerKey {
        
        private AnswerKeyQuestion[] questionField;
        
        private AnswerKeyQualificationValueMapping qualificationValueMappingField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Question")]
        public AnswerKeyQuestion[] Question {
            get {
                return this.questionField;
            }
            set {
                this.questionField = value;
            }
        }
        
        /// <remarks/>
        public AnswerKeyQualificationValueMapping QualificationValueMapping {
            get {
                return this.qualificationValueMappingField;
            }
            set {
                this.qualificationValueMappingField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQuestion {
        
        private string questionIdentifierField;
        
        private AnswerKeyQuestionAnswerOption[] answerOptionField;
        
        private int defaultScoreField;
        
        private bool defaultScoreFieldSpecified;
        
        /// <remarks/>
        public string QuestionIdentifier {
            get {
                return this.questionIdentifierField;
            }
            set {
                this.questionIdentifierField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnswerOption")]
        public AnswerKeyQuestionAnswerOption[] AnswerOption {
            get {
                return this.answerOptionField;
            }
            set {
                this.answerOptionField = value;
            }
        }
        
        /// <remarks/>
        public int DefaultScore {
            get {
                return this.defaultScoreField;
            }
            set {
                this.defaultScoreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultScoreSpecified {
            get {
                return this.defaultScoreFieldSpecified;
            }
            set {
                this.defaultScoreFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQuestionAnswerOption {
        
        private string[] selectionIdentifierField;
        
        private int answerScoreField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SelectionIdentifier")]
        public string[] SelectionIdentifier {
            get {
                return this.selectionIdentifierField;
            }
            set {
                this.selectionIdentifierField = value;
            }
        }
        
        /// <remarks/>
        public int AnswerScore {
            get {
                return this.answerScoreField;
            }
            set {
                this.answerScoreField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQualificationValueMapping {
        
        private object itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PercentageMapping", typeof(AnswerKeyQualificationValueMappingPercentageMapping))]
        [System.Xml.Serialization.XmlElementAttribute("RangeMapping", typeof(AnswerKeyQualificationValueMappingRangeMapping))]
        [System.Xml.Serialization.XmlElementAttribute("ScaleMapping", typeof(AnswerKeyQualificationValueMappingScaleMapping))]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQualificationValueMappingPercentageMapping {
        
        private int maximumSummedScoreField;
        
        /// <remarks/>
        public int MaximumSummedScore {
            get {
                return this.maximumSummedScoreField;
            }
            set {
                this.maximumSummedScoreField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQualificationValueMappingRangeMapping {
        
        private AnswerKeyQualificationValueMappingRangeMappingSummedScoreRange[] summedScoreRangeField;
        
        private int outOfRangeQualificationValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SummedScoreRange")]
        public AnswerKeyQualificationValueMappingRangeMappingSummedScoreRange[] SummedScoreRange {
            get {
                return this.summedScoreRangeField;
            }
            set {
                this.summedScoreRangeField = value;
            }
        }
        
        /// <remarks/>
        public int OutOfRangeQualificationValue {
            get {
                return this.outOfRangeQualificationValueField;
            }
            set {
                this.outOfRangeQualificationValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQualificationValueMappingRangeMappingSummedScoreRange {
        
        private int inclusiveLowerBoundField;
        
        private int inclusiveUpperBoundField;
        
        private int qualificationValueField;
        
        /// <remarks/>
        public int InclusiveLowerBound {
            get {
                return this.inclusiveLowerBoundField;
            }
            set {
                this.inclusiveLowerBoundField = value;
            }
        }
        
        /// <remarks/>
        public int InclusiveUpperBound {
            get {
                return this.inclusiveUpperBoundField;
            }
            set {
                this.inclusiveUpperBoundField = value;
            }
        }
        
        /// <remarks/>
        public int QualificationValue {
            get {
                return this.qualificationValueField;
            }
            set {
                this.qualificationValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://mechanicalturk.amazonaws.com/AWSMechanicalTurkDataSchemas/2005-10-01/Answe" +
        "rKey.xsd")]
    public partial class AnswerKeyQualificationValueMappingScaleMapping {
        
        private double summedScoreMultiplierField;
        
        /// <remarks/>
        public double SummedScoreMultiplier {
            get {
                return this.summedScoreMultiplierField;
            }
            set {
                this.summedScoreMultiplierField = value;
            }
        }
    }
}
