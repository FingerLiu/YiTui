<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <!-- Rename the root element -->
    <xsl:element name="Movies">
      <xsl:apply-templates select="DvdList/DVD"></xsl:apply-templates>
    </xsl:element>
  </xsl:template>

  <xsl:template match="DVD">
    <!-- Transform the <DVD> element into a new element with a different structure. -->
    <xsl:element name="DVD">
      <xsl:attribute name="ID">
        <xsl:value-of select="@ID"/>
      </xsl:attribute>
      <!-- Put the nested <Title> into an attribute. -->
      <xsl:attribute name="Title">
        <xsl:value-of select="Title/text()"/>
      </xsl:attribute>
      <xsl:apply-templates select="Starring/Star" />
    </xsl:element>
  </xsl:template>

  <xsl:template match="Star">
    <xsl:element name="Star">
      <xsl:attribute name="Name">
        <xsl:value-of select="text()"/>
      </xsl:attribute>
    </xsl:element>
  </xsl:template>


</xsl:stylesheet>