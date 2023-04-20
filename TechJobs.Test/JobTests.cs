namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            Assert.IsFalse(job1.Id == job2.Id);
            Assert.IsTrue(job2.Id - job1.Id == 1);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.AreEqual("Product tester", job.Name);
            Assert.AreEqual("ACME", job.EmployerName.Value);
            Assert.AreEqual("Desert", job.EmployerLocation.Value);
            Assert.AreEqual("Quality control", job.JobType.Value);
            Assert.AreEqual("Persistence", job.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job job2 = new Job("Quality assurance", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(job1.Equals(job2));
        }

        //Task 5 Tests

        [TestMethod]
        public void TestToStringStartsAndEndsWithNewLine()
        {
            Job job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string jobToString = job.ToString();
            Assert.IsTrue(jobToString.StartsWith(Environment.NewLine));
            Assert.IsTrue(jobToString.EndsWith(Environment.NewLine));
        }

        [TestMethod]
        public void TestToStringContainsCorrectLabelsAndData()
        {
            Job job = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string jobToString = job.ToString();

            string expectedString = string.Format($"{Environment.NewLine}ID: {job.Id}{Environment.NewLine}Name: Product tester{Environment.NewLine}Employer: ACME{Environment.NewLine}Location: Desert{Environment.NewLine}Position Type: Quality control{Environment.NewLine}Core Competency: Persistence{Environment.NewLine}");
            Assert.AreEqual(expectedString, jobToString);
        }

        [TestMethod]
        public void TestToStringHandlesEmptyField()
        {
            Job job = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            string jobToString = job.ToString();

            string expectedString = string.Format($"{Environment.NewLine}ID: {job.Id}{Environment.NewLine}Name: Data not available{Environment.NewLine}Employer: Data not available{Environment.NewLine}Location: Data not available{Environment.NewLine}Position Type: Data not available{Environment.NewLine}Core Competency: Data not available{Environment.NewLine}");
            Assert.AreEqual(expectedString, jobToString);
        }
    }
}