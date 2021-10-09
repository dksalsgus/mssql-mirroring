
namespace DBState
{
    partial class FrmMain
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
            this.btnACSFailOver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHACSSync = new System.Windows.Forms.Label();
            this.lblHACSState = new System.Windows.Forms.Label();
            this.txtACSSync = new System.Windows.Forms.TextBox();
            this.txtACSState = new System.Windows.Forms.TextBox();
            this.txtPLCState = new System.Windows.Forms.TextBox();
            this.txtPLCSync = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPLCFailOver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 66);
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
            // btnACSFailOver
            // 
            this.btnACSFailOver.Location = new System.Drawing.Point(134, 179);
            this.btnACSFailOver.Name = "btnACSFailOver";
            this.btnACSFailOver.Size = new System.Drawing.Size(75, 23);
            this.btnACSFailOver.TabIndex = 4;
            this.btnACSFailOver.Text = "전환";
            this.btnACSFailOver.UseVisualStyleBackColor = true;
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
            this.lblHACSSync.Location = new System.Drawing.Point(38, 87);
            this.lblHACSSync.Name = "lblHACSSync";
            this.lblHACSSync.Size = new System.Drawing.Size(69, 12);
            this.lblHACSSync.TabIndex = 6;
            this.lblHACSSync.Text = "동기화 상태";
            // 
            // lblHACSState
            // 
            this.lblHACSState.AutoSize = true;
            this.lblHACSState.Location = new System.Drawing.Point(66, 127);
            this.lblHACSState.Name = "lblHACSState";
            this.lblHACSState.Size = new System.Drawing.Size(29, 12);
            this.lblHACSState.TabIndex = 8;
            this.lblHACSState.Text = "상태";
            // 
            // txtACSSync
            // 
            this.txtACSSync.Location = new System.Drawing.Point(113, 84);
            this.txtACSSync.Name = "txtACSSync";
            this.txtACSSync.ReadOnly = true;
            this.txtACSSync.Size = new System.Drawing.Size(121, 21);
            this.txtACSSync.TabIndex = 10;
            // 
            // txtACSState
            // 
            this.txtACSState.Location = new System.Drawing.Point(113, 124);
            this.txtACSState.Name = "txtACSState";
            this.txtACSState.ReadOnly = true;
            this.txtACSState.Size = new System.Drawing.Size(121, 21);
            this.txtACSState.TabIndex = 11;
            // 
            // txtPLCState
            // 
            this.txtPLCState.Location = new System.Drawing.Point(361, 124);
            this.txtPLCState.Name = "txtPLCState";
            this.txtPLCState.ReadOnly = true;
            this.txtPLCState.Size = new System.Drawing.Size(117, 21);
            this.txtPLCState.TabIndex = 15;
            // 
            // txtPLCSync
            // 
            this.txtPLCSync.Location = new System.Drawing.Point(361, 84);
            this.txtPLCSync.Name = "txtPLCSync";
            this.txtPLCSync.ReadOnly = true;
            this.txtPLCSync.Size = new System.Drawing.Size(117, 21);
            this.txtPLCSync.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "상태";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "동기화 상태";
            // 
            // btnPLCFailOver
            // 
            this.btnPLCFailOver.Location = new System.Drawing.Point(381, 179);
            this.btnPLCFailOver.Name = "btnPLCFailOver";
            this.btnPLCFailOver.Size = new System.Drawing.Size(75, 23);
            this.btnPLCFailOver.TabIndex = 16;
            this.btnPLCFailOver.Text = "전환";
            this.btnPLCFailOver.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 214);
            this.Controls.Add(this.btnPLCFailOver);
            this.Controls.Add(this.txtPLCState);
            this.Controls.Add(this.txtPLCSync);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtACSState);
            this.Controls.Add(this.txtACSSync);
            this.Controls.Add(this.lblHACSState);
            this.Controls.Add(this.lblHACSSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnACSFailOver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnACSFailOver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHACSSync;
        private System.Windows.Forms.Label lblHACSState;
        private System.Windows.Forms.TextBox txtACSSync;
        private System.Windows.Forms.TextBox txtACSState;
        private System.Windows.Forms.TextBox txtPLCState;
        private System.Windows.Forms.TextBox txtPLCSync;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPLCFailOver;
    }
}

