# How to publish

...

# Github actions secrets

To run the GitHub actions, you need to set up the following secrets in your GitHub repository in order to authenticate to the private NuGet package:

- **GH_PAT**: GitHub Personal Access Token with `write:packages` and `read:packages` scopes
- **GH_PRIVATE_FEED_URL**: URL of the private NuGet feed
- **GH_USERNAME**: GitHub username