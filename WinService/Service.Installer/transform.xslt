<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:wix="http://schemas.microsoft.com/wix/2006/wi"                
                version="1.0">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()" />
    </xsl:copy>
  </xsl:template>

  <!-- Remove Service.exe file entry -->
  <xsl:template match="//wix:File[@Source='$(var.BuildLocation)\Service.exe']">
    <!-- add CreateFolder or you will get an error 
         KeyPath for component: XXXXXXXX   is a Directory: XXXXXXXX. The directory/component pair must be listed in the CreateFolders table -->
    <wix:CreateFolder/>
  </xsl:template> 
</xsl:stylesheet>