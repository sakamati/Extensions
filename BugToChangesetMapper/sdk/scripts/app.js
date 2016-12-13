VSS.init({
    explicitNotifyLoaded: true,
    usePlatformScripts: true,
    usePlatformStyles: true
});

VSS.require(["VSS/Service", "TFS/WorkItemTracking/RestClient", "VSS/Controls", "VSS/Controls/TreeView", "VSS/Controls/Grids"],
function (VSS_Service, TFS_Wit_WebApi, Controls, TreeView, Grids) {
    // Get the REST client
    var witClient = VSS_Service.getCollectionClient(TFS_Wit_WebApi.WorkItemTrackingHttpClient);
    var projectId = VSS.getWebContext().project.id;

    // Converts the source to TreeNodes
    function convertToTreeNodes(items) {
        return $.map(items, function (item) {
            var node = new TreeView.TreeNode(item.name);
            node.icon = item.icon;
            node.expanded = item.expanded;
            node.link = "#" + item.id;
            if (item.children && item.children.length > 0) {
                node.addRange(convertToTreeNodes(item.children));
            }
            return node;
        });
    }

    witClient.getQueries(projectId, "All", 2, false).then(
        function (queries) {

            var treeViewOptions = {
                width: 400,
                height: "100%",
                nodes: convertToTreeNodes(queries)
            };
            // Create the treeView in a container element
            var treeview = Controls.create(TreeView.TreeView, $("#treeview-container"), treeViewOptions);

        },
        function (reject) {
            handleCommunicationError(reject);
        });

    var container = $("#treeview-container");

    // Attach selectionchanged event using a DOM element containing treeview
    container.bind("selectionchanged", function (e, args) {
        clearWorkItemGrid();
        var selectedNode = args.selectedNode;
        if (selectedNode) {
            witClient.queryById(selectedNode.link.substr(1, selectedNode.link.length - 1))
                .then(function (result) {
                    refreshGrid(Controls, Grids, witClient, result.columns, result.workItems);
                    hideProgressIndicator();
                }, function (reject) {
                    handleCommunicationError(reject);
                    hideProgressIndicator();
                });
            //alert('${selectedNode.text} selected!');
        }
    });

    $("#refreshResult").click(function () {
        clearWorkItemGrid();
        var commaSeparatedBugIds = $("#bugIds").val();
        buildWorkItemGrid(Controls, Grids, witClient, [commaSeparatedBugIds], null);
    });
    VSS.notifyLoadSucceeded();
});

function refreshGrid(Controls, Grids, witClient, columns, workItems) {
    var commaSeparatedBugIds = "";

    workItems.forEach(function (workitem, index) {
        commaSeparatedBugIds += workitem.id + ",";
    });

    if (commaSeparatedBugIds.lastIndexOf(",") == commaSeparatedBugIds.length - 1) {
        commaSeparatedBugIds = commaSeparatedBugIds.slice(0, commaSeparatedBugIds.length - 1);
    }

    buildWorkItemGrid(Controls, Grids, witClient, [commaSeparatedBugIds], columns);
}

function buildWorkItemGrid(Controls, Grids, witClient, witIdArray, columns) {
    var changesetPattern = new RegExp("vstfs:///VersionControl/Changeset/([0-9]*)", "i");
    showProgressIndicator();
    witClient.getWorkItems(witIdArray, undefined, undefined, "All").then(
            function (workitems) {
                var gridColumns = [], dataSource = [];

                gridColumns.push({ text: "S.No", index: "sno" });
                if (columns) {
                    columns.forEach(function (column, index) {
                        gridColumns.push({ text: column.name, index: column.referenceName });
                    });
                }
                else {
                    gridColumns.push({ text: "ID", index: "System.Id" });
                    gridColumns.push({ text: "Title", index: "System.Title" });
                    gridColumns.push({ text: "Severity", index: "Microsoft.VSTS.Common.Severity" });
                    gridColumns.push({ text: "Created By", index: "System.CreatedBy" });
                    gridColumns.push({ text: "Area Path", index: "System.AreaPath" });
                }
                gridColumns.push({ text: "Changeset", index: "Changeset" });

                workitems.forEach(function (workitem, index) {
                    var changesetNumber = "";

                    for (var j = 0; workitem.relations && j < workitem.relations.length; j++) {
                        var relation = workitem.relations[j];
                        if (!relation.url) continue;
                        var changesetMatches = changesetPattern.exec(relation.url);
                        if (changesetMatches && changesetMatches.length > 1) {
                            changesetNumber = (changesetNumber == "" ? "" : (changesetNumber + ", ")) + changesetMatches[1];
                        }
                    }
                    var dataItem = {};
                    gridColumns.forEach(function (gridColumn) {
                        dataItem[gridColumn.index] = workitem.fields[gridColumn.index];
                    });
                    dataItem["sno"] = index + 1;
                    dataItem["Changeset"] = changesetNumber;
                    dataSource.push(dataItem);
                });

                var gridOptions = {
                    height: "100%",
                    width: "100%",
                    source: dataSource,
                    columns: gridColumns
                };

                var grid = Controls.create(Grids.Grid, $("#grid-container"), gridOptions);
                hideProgressIndicator();
            }, function (reject) {
                handleCommunicationError(reject);
                hideProgressIndicator();
            });
}

function handleCommunicationError(reason) {
    var message = reason;
    if (reason.message) {
        message = reason.message;
    }
    //var errorElement = $("#error");
    //errorElement.text(message);
    //errorElement.css("display", "block");
    alert(message);
}

function clearWorkItemGrid() {
    $("#grid-container").empty();
}

function showProgressIndicator() {
    //$("#status-indicator").show();
    $("#progressIndicator").css("visibility", "visible");
}

function hideProgressIndicator() {
    //$("#status-indicator").hide();
    $("#progressIndicator").css("visibility", "hidden");
}