/* Yet Another Forum.NET
 * Copyright (C) 2006-2012 Jaben Cargman
 * http://www.yetanotherforum.net/
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 */
namespace YAF.Controls
{
  #region Using

  using System;

  using YAF.Core;
  using YAF.Types;

  #endregion

  /// <summary>
  /// The forum icon legend.
  /// </summary>
  public partial class ForumIconLegend : BaseUserControl
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref = "ForumIconLegend" /> class.
    /// </summary>
    public ForumIconLegend()
    {
      this.PreRender += this.ForumIconLegend_PreRender;
    }

    #endregion

    #region Methods

    /// <summary>
    /// The forum icon legend_ pre render.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void ForumIconLegend_PreRender([NotNull] object sender, [NotNull] EventArgs e)
    {
    }

    #endregion
  }
}