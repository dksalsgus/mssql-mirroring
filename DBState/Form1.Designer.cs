
namespace DBState
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHACSSync = new System.Windows.Forms.Label();
            this.lblHPLCSync = new System.Windows.Forms.Label();
            this.lblHACSState = new System.Windows.Forms.Label();
            this.lblHPLCState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "ACS 데이터베이스 현재상태";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(450, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "PLC 데이터베이스 현재상태";
            // 
            // lblHACSSync
            // 
            this.lblHACSSync.AutoSize = true;
            this.lblHACSSync.Location = new System.Drawing.Point(116, 99);
            this.lblHACSSync.Name = "lblHACSSync";
            this.lblHACSSync.Size = new System.Drawing.Size(38, 12);
            this.lblHACSSync.TabIndex = 6;
            this.lblHACSSync.Text = "label4";
            // 
            // lblHPLCSync
            // 
            this.lblHPLCSync.AutoSize = true;
            this.lblHPLCSync.Location = new System.Drawing.Point(381, 99);
            this.lblHPLCSync.Name = "lblHPLCSync";
            this.lblHPLCSync.Size = new System.Drawing.Size(38, 12);
            this.lblHPLCSync.TabIndex = 7;
            this.lblHPLCSync.Text = "label5";
            // 
            // lblHACSState
            // 
            this.lblHACSState.AutoSize = true;
            this.lblHACSState.Location = new System.Drawing.Point(116, 141);
            this.lblHACSState.Name = "lblHACSState";
            this.lblHACSState.Size = new System.Drawing.Size(38, 12);
            this.lblHACSState.TabIndex = 8;
            this.lblHACSState.Text = "label4";
            // 
            // lblHPLCState
            // 
            this.lblHPLCState.AutoSize = true;
            this.lblHPLCState.Location = new System.Drawing.Point(381, 141);
            this.lblHPLCState.Name = "lblHPLCState";
            this.lblHPLCState.Size = new System.Drawing.Size(38, 12);
            this.lblHPLCState.TabIndex = 9;
            this.lblHPLCState.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 214);
            this.Controls.Add(this.lblHPLCState);
            this.Controls.Add(this.lblHACSState);
            this.Controls.Add(this.lblHPLCSync);
            this.Controls.Add(this.lblHACSSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHACSSync;
        private System.Windows.Forms.Label lblHPLCSync;
        private System.Windows.Forms.Label lblHACSState;
        private System.Windows.Forms.Label lblHPLCState;
    }
}

