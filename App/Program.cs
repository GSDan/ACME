// BEFORE RUNNING
// Create a local database and update the connection string in AcmeContext.cs
// Run 'Update-Database' in the package manager console

// To run on a regular basis, run this console app in a cron job
// (e.g. "001**" will run at midnight on the first day of each month)

using App;

SubscriptionManager manager = new SubscriptionManager();

await manager.RequestDistribution();