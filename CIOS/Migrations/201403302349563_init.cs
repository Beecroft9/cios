namespace CIOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        addressId = c.Int(nullable: false, identity: true),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zipcode = c.String(),
                    })
                .PrimaryKey(t => t.addressId);
            
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        employerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        contactId = c.Int(nullable: false),
                        addressId = c.Int(nullable: false),
                        companyName = c.String(),
                        webAddress = c.String(),
                        numOfEmployees = c.Int(nullable: false),
                        numYearsInOperation = c.Int(),
                        briefDescription = c.String(),
                        isActive = c.Boolean(nullable: false),
                        lastAccess = c.DateTime(nullable: false),
                        hasIntern = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.employerId)
                .ForeignKey("dbo.Address", t => t.addressId)
                .ForeignKey("dbo.Contact", t => t.contactId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.contactId)
                .Index(t => t.addressId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        title = c.String(),
                        phone = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.contactId);
            
            CreateTable(
                "dbo.LearningAgreement",
                c => new
                    {
                        learningAgreementId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        employerId = c.Int(nullable: false),
                        contactId = c.Int(nullable: false),
                        courseNumber = c.String(),
                        courseCreditHours = c.Int(nullable: false),
                        expectedHours = c.Int(nullable: false),
                        hourlyPay = c.Double(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        objectives = c.String(),
                    })
                .PrimaryKey(t => t.learningAgreementId)
                .ForeignKey("dbo.Contact", t => t.contactId)
                .ForeignKey("dbo.Employer", t => t.employerId)
                .ForeignKey("dbo.Student", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.employerId)
                .Index(t => t.contactId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        studentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        altEmailAddress = c.String(),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        eNumber = c.String(),
                        altPhone = c.String(),
                        cellPhone = c.String(),
                        targetSemester = c.String(),
                        internshipCompleted = c.Boolean(),
                        addressId = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        lastAccess = c.DateTime(nullable: false),
                        hasInternship = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.studentId)
                .ForeignKey("dbo.Address", t => t.addressId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.addressId);
            
            CreateTable(
                "dbo.Dropbox",
                c => new
                    {
                        dropboxId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        quiz = c.Boolean(),
                        midTermMemo = c.Boolean(),
                        finalReport = c.Boolean(),
                        employerEval = c.Boolean(),
                        exitInterview = c.Boolean(),
                    })
                .PrimaryKey(t => t.dropboxId)
                .ForeignKey("dbo.Student", t => t.studentId)
                .Index(t => t.studentId);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        evaluationId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        opportunityId = c.Int(nullable: false),
                        attitude = c.String(),
                        abilityToLearn = c.String(),
                        judgement = c.String(),
                        dependability = c.String(),
                        initiative = c.String(),
                        relationshipWithOthers = c.String(),
                        maturity = c.String(),
                        qualityOfWork = c.String(),
                        attendance = c.String(),
                        punctuality = c.String(),
                        outstandingPersonalQualities = c.String(),
                        needToImprove = c.String(),
                        discussedWithStudent = c.Boolean(),
                    })
                .PrimaryKey(t => t.evaluationId)
                .ForeignKey("dbo.Opportunity", t => t.opportunityId)
                .ForeignKey("dbo.Student", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.opportunityId);
            
            CreateTable(
                "dbo.Opportunity",
                c => new
                    {
                        opportunityId = c.Int(nullable: false, identity: true),
                        employerId = c.Int(nullable: false),
                        contactId = c.Int(nullable: false),
                        state = c.String(),
                        city = c.String(),
                        compensated = c.Boolean(),
                        payRate = c.Double(),
                        applicationDeadline = c.DateTime(nullable: false),
                        positionDescription = c.String(),
                        contactMailingAddress = c.String(),
                    })
                .PrimaryKey(t => t.opportunityId)
                .ForeignKey("dbo.Contact", t => t.contactId)
                .ForeignKey("dbo.Employer", t => t.employerId)
                .Index(t => t.employerId)
                .Index(t => t.contactId);
            
            CreateTable(
                "dbo.Major",
                c => new
                    {
                        majorId = c.Int(nullable: false, identity: true),
                        departmentId = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.majorId)
                .ForeignKey("dbo.Department", t => t.departmentId)
                .Index(t => t.departmentId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        departmentId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.departmentId);
            
            CreateTable(
                "dbo.Advisor",
                c => new
                    {
                        advisorId = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        departmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.advisorId)
                .ForeignKey("dbo.Department", t => t.departmentId)
                .Index(t => t.departmentId);
            
            CreateTable(
                "dbo.DepartmentChair",
                c => new
                    {
                        departmentChairId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        departmentId = c.Int(nullable: false),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.departmentChairId)
                .ForeignKey("dbo.Department", t => t.departmentId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.departmentId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.StudentMajor",
                c => new
                    {
                        studentMajorId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        majorId = c.Int(nullable: false),
                        overallGPA = c.Double(),
                        majorGPA = c.Double(),
                        hoursCompleted = c.Int(),
                        expectedGraduation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.studentMajorId)
                .ForeignKey("dbo.Major", t => t.majorId)
                .ForeignKey("dbo.Student", t => t.studentId)
                .Index(t => t.studentId)
                .Index(t => t.majorId);
            
            CreateTable(
                "dbo.StudentAppointment",
                c => new
                    {
                        studentAppointmentId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        appointment = c.DateTime(nullable: false),
                        targetStartTopic = c.String(),
                        goals = c.String(),
                        resumeCoached = c.Boolean(),
                        resumeReviewed = c.Boolean(),
                        resumeCompleted = c.Boolean(),
                        classHours = c.String(),
                        timeAvailable = c.String(),
                        goalNotes = c.String(),
                        resumeNotes = c.String(),
                        factorsNotes = c.String(),
                        studentLeads = c.String(),
                        studentCBATOpt = c.String(),
                        actionPlan = c.String(),
                    })
                .PrimaryKey(t => t.studentAppointmentId)
                .ForeignKey("dbo.Student", t => t.studentId)
                .Index(t => t.studentId);
            
            CreateTable(
                "dbo.CSPersonnel",
                c => new
                    {
                        csPersonnelId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        isActive = c.Boolean(nullable: false),
                        lastAccess = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.csPersonnelId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OpportunityMajor",
                c => new
                    {
                        MajorId = c.Int(nullable: false),
                        OpportunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MajorId, t.OpportunityId })
                .ForeignKey("dbo.Major", t => t.MajorId)
                .ForeignKey("dbo.Opportunity", t => t.OpportunityId)
                .Index(t => t.MajorId)
                .Index(t => t.OpportunityId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        scheduleId = c.Int(nullable: false, identity: true),
                        quizDueDate = c.DateTime(nullable: false),
                        midTermDate = c.DateTime(nullable: false),
                        paperDueDate = c.DateTime(nullable: false),
                        evalFormDueDate = c.DateTime(nullable: false),
                        exitInterviewDueDate = c.DateTime(nullable: false),
                        quizReminder = c.DateTime(nullable: false),
                        midReminder = c.DateTime(nullable: false),
                        paperReminder = c.DateTime(nullable: false),
                        evalReminder = c.DateTime(nullable: false),
                        exitInterviewReminder = c.DateTime(nullable: false),
                        employerUpdateReminder = c.DateTime(nullable: false),
                        employerEvaluationReminder = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.scheduleId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        stateId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.stateId);
            
            CreateTable(
                "dbo.MajorOpportunity",
                c => new
                    {
                        Major_majorId = c.Int(nullable: false),
                        Opportunity_opportunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Major_majorId, t.Opportunity_opportunityId })
                .ForeignKey("dbo.Major", t => t.Major_majorId, cascadeDelete: true)
                .ForeignKey("dbo.Opportunity", t => t.Opportunity_opportunityId, cascadeDelete: true)
                .Index(t => t.Major_majorId)
                .Index(t => t.Opportunity_opportunityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpportunityMajor", "OpportunityId", "dbo.Opportunity");
            DropForeignKey("dbo.OpportunityMajor", "MajorId", "dbo.Major");
            DropForeignKey("dbo.CSPersonnel", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Employer", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Student", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StudentAppointment", "studentId", "dbo.Student");
            DropForeignKey("dbo.LearningAgreement", "studentId", "dbo.Student");
            DropForeignKey("dbo.Evaluation", "studentId", "dbo.Student");
            DropForeignKey("dbo.StudentMajor", "studentId", "dbo.Student");
            DropForeignKey("dbo.StudentMajor", "majorId", "dbo.Major");
            DropForeignKey("dbo.MajorOpportunity", "Opportunity_opportunityId", "dbo.Opportunity");
            DropForeignKey("dbo.MajorOpportunity", "Major_majorId", "dbo.Major");
            DropForeignKey("dbo.Major", "departmentId", "dbo.Department");
            DropForeignKey("dbo.DepartmentChair", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.DepartmentChair", "departmentId", "dbo.Department");
            DropForeignKey("dbo.Advisor", "departmentId", "dbo.Department");
            DropForeignKey("dbo.Evaluation", "opportunityId", "dbo.Opportunity");
            DropForeignKey("dbo.Opportunity", "employerId", "dbo.Employer");
            DropForeignKey("dbo.Opportunity", "contactId", "dbo.Contact");
            DropForeignKey("dbo.Dropbox", "studentId", "dbo.Student");
            DropForeignKey("dbo.Student", "addressId", "dbo.Address");
            DropForeignKey("dbo.LearningAgreement", "employerId", "dbo.Employer");
            DropForeignKey("dbo.LearningAgreement", "contactId", "dbo.Contact");
            DropForeignKey("dbo.Employer", "contactId", "dbo.Contact");
            DropForeignKey("dbo.Employer", "addressId", "dbo.Address");
            DropIndex("dbo.MajorOpportunity", new[] { "Opportunity_opportunityId" });
            DropIndex("dbo.MajorOpportunity", new[] { "Major_majorId" });
            DropIndex("dbo.OpportunityMajor", new[] { "OpportunityId" });
            DropIndex("dbo.OpportunityMajor", new[] { "MajorId" });
            DropIndex("dbo.CSPersonnel", new[] { "UserId" });
            DropIndex("dbo.StudentAppointment", new[] { "studentId" });
            DropIndex("dbo.StudentMajor", new[] { "majorId" });
            DropIndex("dbo.StudentMajor", new[] { "studentId" });
            DropIndex("dbo.DepartmentChair", new[] { "departmentId" });
            DropIndex("dbo.DepartmentChair", new[] { "UserId" });
            DropIndex("dbo.Advisor", new[] { "departmentId" });
            DropIndex("dbo.Major", new[] { "departmentId" });
            DropIndex("dbo.Opportunity", new[] { "contactId" });
            DropIndex("dbo.Opportunity", new[] { "employerId" });
            DropIndex("dbo.Evaluation", new[] { "opportunityId" });
            DropIndex("dbo.Evaluation", new[] { "studentId" });
            DropIndex("dbo.Dropbox", new[] { "studentId" });
            DropIndex("dbo.Student", new[] { "addressId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.LearningAgreement", new[] { "contactId" });
            DropIndex("dbo.LearningAgreement", new[] { "employerId" });
            DropIndex("dbo.LearningAgreement", new[] { "studentId" });
            DropIndex("dbo.Employer", new[] { "addressId" });
            DropIndex("dbo.Employer", new[] { "contactId" });
            DropIndex("dbo.Employer", new[] { "UserId" });
            DropTable("dbo.MajorOpportunity");
            DropTable("dbo.State");
            DropTable("dbo.Schedule");
            DropTable("dbo.OpportunityMajor");
            DropTable("dbo.CSPersonnel");
            DropTable("dbo.StudentAppointment");
            DropTable("dbo.StudentMajor");
            DropTable("dbo.UserProfile");
            DropTable("dbo.DepartmentChair");
            DropTable("dbo.Advisor");
            DropTable("dbo.Department");
            DropTable("dbo.Major");
            DropTable("dbo.Opportunity");
            DropTable("dbo.Evaluation");
            DropTable("dbo.Dropbox");
            DropTable("dbo.Student");
            DropTable("dbo.LearningAgreement");
            DropTable("dbo.Contact");
            DropTable("dbo.Employer");
            DropTable("dbo.Address");
        }
    }
}
