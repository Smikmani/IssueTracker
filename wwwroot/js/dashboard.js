
window.chartColors = {
	red: '#808080',
	orange: 'rgb(255, 159, 64)',
	yellow: 'rgb(255, 205, 86)',
	green: 'rgb(75, 192, 192)',
	blue: 'rgb(54, 162, 235)',
	purple: 'rgb(153, 102, 255)',
	grey: 'rgb(201, 203, 207)'
};

function getPieChart(chartId, colors, data, labels) {
	
	var ctx = document.getElementById(chartId).getContext('2d');

	var config = {
		type: 'doughnut',
		data: {
			datasets: [{
				data,
				backgroundColor: colors,
				label: 'Dataset 1'
			}],
			labels
		},
		options: {
			responsive: true,
			legend: {
				display : false
			},
			title: {
				display: false
			},
			animation: {
				animateScale: true,
				animateRotate: true
			}
		}
	};

	var chart = new Chart(ctx, config);
}

function getLineChart(chartId,  data, labels) {
	var ctx = document.getElementById(chartId).getContext('2d');

	var config = {
		// The type of chart we want to create
		type: 'line',

		// The data for our dataset
		data: {
			labels,
			datasets: [{
				backgroundColor: 'rgb(54,185,204,0.05)',
				borderColor: 'rgb(54,185,204)',
				data
			}]
		},

		// Configuration options go here
		options: {
			scales: {
				xAxes: [{
					time: {
						unit: 'date'
					},
					gridLines: {
						display: false,
						drawBorder: false
					},
					ticks: {
						maxTicksLimit: 7
					}
				}],
				yAxes: [{
					ticks: {
						maxTicksLimit: 7,
						padding: 5,
						// Include a dollar sign in the ticks
					},
					gridLines: {
						color: "rgb(234, 236, 244)",
						zeroLineColor: "rgb(234, 236, 244)",
						drawBorder: false,
						borderDash: [2],
						zeroLineBorderDash: [2]
					}
				}],
			},
			responsive: true,
			legend: {
				display: false
			},
			title: {
				display: false
			}
		}
	};

	var chart = new Chart(ctx, config);
}