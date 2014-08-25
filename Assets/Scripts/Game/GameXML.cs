/// <summary>
/// Proceed to the GameController to understand more about the structure of the Game Engine.
/// 
/// This namespace contains the "Model" for the GameController. It stores the Game State,
/// as loaded from an XML file. This class was automatically generated from an XML file that
/// was hand-written, and then converted to a schema defination file using an online tool. 
/// The actual class was generated using MonoXDS. MonoXDS is an alternative to the XDS utility
/// that comes with Visual Studio.
/// The XML is quite extensive. Some tags, such as the rotation/position etc are meant for 
/// future expansion. They exist, and can be read already, but are not used in the game.
/// 
/// Note: MonoXDS had trouble converting the original XML directly into a schema, so I used
/// an online tool instead, with some manual changes.
///  
/// </summary>
namespace Schemas {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GameXML {
        
        private GameXMLScene[] sceneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Scene")]
        public GameXMLScene[] Scene {
            get {
                return this.sceneField;
            }
            set {
                this.sceneField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLScene {
        
        private string idField;
        
        private GameXMLSceneItem itemField;
        
        private GameXMLScenePickableItem[] pickableItemField;
        
        private GameXMLSceneNavigationItem[] navigationItemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneItem Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PickableItem")]
        public GameXMLScenePickableItem[] PickableItem {
            get {
                return this.pickableItemField;
            }
            set {
                this.pickableItemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NavigationItem")]
        public GameXMLSceneNavigationItem[] NavigationItem {
            get {
                return this.navigationItemField;
            }
            set {
                this.navigationItemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneItem {
        
        private string nameField;
        
        private string resourcePathField;
        
        private string infoField;
        
        private GameXMLSceneItemPosition positionField;
        
        private GameXMLSceneItemRotation rotationField;
        
        private GameXMLSceneItemScale scaleField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string ResourcePath {
            get {
                return this.resourcePathField;
            }
            set {
                this.resourcePathField = value;
            }
        }
        
        /// <remarks/>
        public string Info {
            get {
                return this.infoField;
            }
            set {
                this.infoField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneItemPosition Position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneItemRotation Rotation {
            get {
                return this.rotationField;
            }
            set {
                this.rotationField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneItemScale Scale {
            get {
                return this.scaleField;
            }
            set {
                this.scaleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneItemPosition {
        
        private decimal xField;
        
        private decimal yField;
        
        private decimal zField;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField;
            }
            set {
                this.zField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneItemRotation {
        
        private decimal xField1;
        
        private decimal yField1;
        
        private decimal zField1;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField1;
            }
            set {
                this.xField1 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField1;
            }
            set {
                this.yField1 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField1;
            }
            set {
                this.zField1 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneItemScale {
        
        private decimal xField2;
        
        private decimal yField2;
        
        private decimal zField2;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField2;
            }
            set {
                this.xField2 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField2;
            }
            set {
                this.yField2 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField2;
            }
            set {
                this.zField2 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLScenePickableItem {
        
        private string nameField1;
        
        private string resourcePathField1;
        
        private string infoField1;
        
        private string requiredItemField;
        
        private string pickedMessageField;
        
        private bool isPickedField;
        
        private GameXMLScenePickableItemPosition positionField1;
        
        private GameXMLScenePickableItemRotation rotationField1;
        
        private GameXMLScenePickableItemScale scaleField1;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField1;
            }
            set {
                this.nameField1 = value;
            }
        }
        
        /// <remarks/>
        public string ResourcePath {
            get {
                return this.resourcePathField1;
            }
            set {
                this.resourcePathField1 = value;
            }
        }
        
        /// <remarks/>
        public string Info {
            get {
                return this.infoField1;
            }
            set {
                this.infoField1 = value;
            }
        }
        
        /// <remarks/>
        public string RequiredItem {
            get {
                return this.requiredItemField;
            }
            set {
                this.requiredItemField = value;
            }
        }
        
        /// <remarks/>
        public string PickedMessage {
            get {
                return this.pickedMessageField;
            }
            set {
                this.pickedMessageField = value;
            }
        }
        
        /// <remarks/>
        public bool IsPicked {
            get {
                return this.isPickedField;
            }
            set {
                this.isPickedField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLScenePickableItemPosition Position {
            get {
                return this.positionField1;
            }
            set {
                this.positionField1 = value;
            }
        }
        
        /// <remarks/>
        public GameXMLScenePickableItemRotation Rotation {
            get {
                return this.rotationField1;
            }
            set {
                this.rotationField1 = value;
            }
        }
        
        /// <remarks/>
        public GameXMLScenePickableItemScale Scale {
            get {
                return this.scaleField1;
            }
            set {
                this.scaleField1 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLScenePickableItemPosition {
        
        private decimal xField3;
        
        private decimal yField3;
        
        private decimal zField3;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField3;
            }
            set {
                this.xField3 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField3;
            }
            set {
                this.yField3 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField3;
            }
            set {
                this.zField3 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLScenePickableItemRotation {
        
        private decimal xField4;
        
        private decimal yField4;
        
        private decimal zField4;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField4;
            }
            set {
                this.xField4 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField4;
            }
            set {
                this.yField4 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField4;
            }
            set {
                this.zField4 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLScenePickableItemScale {
        
        private decimal xField5;
        
        private decimal yField5;
        
        private decimal zField5;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField5;
            }
            set {
                this.xField5 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField5;
            }
            set {
                this.yField5 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField5;
            }
            set {
                this.zField5 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneNavigationItem {
        
        private string nameField2;
        
        private string resourcePathField2;
        
        private string infoField2;
        
        private string sceneNameField;
        
        private GameXMLSceneNavigationItemPosition positionField2;
        
        private GameXMLSceneNavigationItemRotation rotationField2;
        
        private GameXMLSceneNavigationItemScale scaleField2;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField2;
            }
            set {
                this.nameField2 = value;
            }
        }
        
        /// <remarks/>
        public string ResourcePath {
            get {
                return this.resourcePathField2;
            }
            set {
                this.resourcePathField2 = value;
            }
        }
        
        /// <remarks/>
        public string Info {
            get {
                return this.infoField2;
            }
            set {
                this.infoField2 = value;
            }
        }
        
        /// <remarks/>
        public string SceneName {
            get {
                return this.sceneNameField;
            }
            set {
                this.sceneNameField = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneNavigationItemPosition Position {
            get {
                return this.positionField2;
            }
            set {
                this.positionField2 = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneNavigationItemRotation Rotation {
            get {
                return this.rotationField2;
            }
            set {
                this.rotationField2 = value;
            }
        }
        
        /// <remarks/>
        public GameXMLSceneNavigationItemScale Scale {
            get {
                return this.scaleField2;
            }
            set {
                this.scaleField2 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneNavigationItemPosition {
        
        private decimal xField6;
        
        private decimal yField6;
        
        private decimal zField6;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField6;
            }
            set {
                this.xField6 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField6;
            }
            set {
                this.yField6 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField6;
            }
            set {
                this.zField6 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneNavigationItemRotation {
        
        private decimal xField7;
        
        private decimal yField7;
        
        private decimal zField7;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField7;
            }
            set {
                this.xField7 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField7;
            }
            set {
                this.yField7 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField7;
            }
            set {
                this.zField7 = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GameXMLSceneNavigationItemScale {
        
        private decimal xField8;
        
        private decimal yField8;
        
        private decimal zField8;
        
        /// <remarks/>
        public decimal x {
            get {
                return this.xField8;
            }
            set {
                this.xField8 = value;
            }
        }
        
        /// <remarks/>
        public decimal y {
            get {
                return this.yField8;
            }
            set {
                this.yField8 = value;
            }
        }
        
        /// <remarks/>
        public decimal z {
            get {
                return this.zField8;
            }
            set {
                this.zField8 = value;
            }
        }
    }
}
