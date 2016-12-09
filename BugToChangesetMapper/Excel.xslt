<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <div id="testTable">
      <table>
        <xsl:for-each select="div[@class='right-hub-content']">
          <xsl:for-each select="div[@class='grid has-header grid-blurred']">
            <xsl:for-each select="div[@class='grid-header']">
              <xsl:for-each select="div[@class='grid-header-canvas']">
                <tr>
                  <xsl:for-each select="div[@class='grid-header-column']">
                    <th>
                      <xsl:value-of select="@title"/>
                    </th>
                  </xsl:for-each>
                </tr>
              </xsl:for-each>
            </xsl:for-each>
            <xsl:for-each select="div[@class='grid-canvas']">
              <xsl:for-each select="div[@role='row']">
                <tr>
                  <xsl:for-each select="div[@class='grid-cell']">
                    <td>
                      <xsl:value-of select="node()"/>
                    </td>
                  </xsl:for-each>
                </tr>
              </xsl:for-each>
            </xsl:for-each>
          </xsl:for-each>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>

