<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <body>
        <xsl:for-each select="//File">
          <table border="1">
            <tr>
              <th>
                <xsl:value-of select="current()" />
              </th>
            </tr>
            <tr>
              <td>
                <xsl:value-of select="@Count" />
              </td>
            </tr>
          </table>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

